using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MeaWorkShop.Validators
{
    public class UpdateMeaWorkShopDtoValidator : AbstractValidator<MeaWorkShopDto>
    {
        public UpdateMeaWorkShopDtoValidator()
        {
            Include(new IMeaWorkShopDtoValidator());

            RuleFor(b => b.MeaWorkShopId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

