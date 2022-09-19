using System;
using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validatörs.Product
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {

            RuleFor(p => p.Name).NotEmpty()
                .NotNull().WithMessage("Lütfen ürün adını boş geçmeyin.")
                .MaximumLength(150).MinimumLength(5).WithMessage("Ürün adı 5-150 karakter arasında olmalı.");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen stok bilgisini boş geçmeyiniz.").Must(m => m >= 0).WithMessage("Stok bilgisi eksi olamaz.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull().WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.").Must(m => m >= 0).WithMessage("Fiyat bilgisi eksi olamaz.");








        }

    }
}

