using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Shop.Validators
{
    public class CreateShopDtoValidator : AbstractValidator<CreateShopDto>
    {
        public CreateShopDtoValidator()
        {
            Include(new IShopDtoValidator());
        }
    }
}
