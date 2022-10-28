﻿using Microsoft.AspNetCore.Diagnostics;
using MiniECommerce.Application;
using System.Text.Json;

namespace MiniECommerce.Persistance
{
    public static class CustomExceptionHandler
    {
        //Yazdıgımız bu middleware ile uygulamada karşımıza çıkıcak bir hatayı handle edip clienta CustomeResponseDto olarak döndürüyoruz.
        public static void UseCustomExeption(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                //Run Devre Kesici Middlawera
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    //IExceptionHandlerFeature üzerinden uygulamada fırlatılan hataları yakalıyoruz.
                    IExceptionHandlerFeature exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //exceptionFeature hatalarında eger client taraflı bir hata ise 400,NoFoundException ise 404, bunun dışında bir hata işe 500 atıyoruz.
                    int statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    //context.Response.StatusCode a yukarıdan gelen hatanın statuscode'unu atıyoruz.
                    context.Response.StatusCode = statusCode;

                    CustomResponseDto<NoContentDto> response;
                    if (statusCode == 404)
                    {
                        response = CustomResponseDto<NoContentDto>.Fail(statusCode, "An Error Occurred", "Hatalı işlem");
                    }

                    //Kendi yazdıgımız CustomResponseDto nun fail methoduna hatanın statuscode'unu ve error mesajını veriyoruz.
                    response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message, "Hatalı işlem");

                    // Response u WriteAsync ile yazdırıyoruz. JsonSerializer.Serialize(response) ile response u json dizesine dönüştürdük.
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });

        }
    }
}
