﻿using System.Text.Json.Serialization;

namespace MiniECommerce.Application
{
    public class NoContentDto
    {

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }


        //static Factory Method Dessing Pattern.
        public static NoContentDto Success(int statusCode)
        {
            return new NoContentDto() { StatusCode = statusCode };
        }

        public static NoContentDto Fail(int statusCode, List<string> errors)
        {
            return new NoContentDto() { StatusCode = statusCode, Errors = errors };
        }

        public static NoContentDto Fail(int statusCode, string error)
        {
            return new NoContentDto() { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
