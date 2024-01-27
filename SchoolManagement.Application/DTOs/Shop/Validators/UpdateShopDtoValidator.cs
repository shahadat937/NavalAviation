using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Shop.Validators
{
    public class UpdateShopDtoValidator : AbstractValidator<ShopDto>
    {
        public UpdateShopDtoValidator()
        {
            Include(new IShopDtoValidator());

            RuleFor(p => p.ShopId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
