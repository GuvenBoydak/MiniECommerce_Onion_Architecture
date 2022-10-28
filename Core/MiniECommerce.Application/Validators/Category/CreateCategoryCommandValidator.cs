﻿using FluentValidation;

namespace MiniECommerce.Application
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori İsmi boş geçilemez").MaximumLength(50).WithMessage("Kategori ismi en fazla 50 karakter olamlıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori Açıklaması alanı boş geçilemez.").MaximumLength(500).WithMessage("Girilen deger en Fazla 500 karakter olmalıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");
        }
    }
}
