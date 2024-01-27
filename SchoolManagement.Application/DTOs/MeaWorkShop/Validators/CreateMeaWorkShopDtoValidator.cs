using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MeaWorkShop.Validators
{
    public class CreateMeaWorkShopDtoValidator : AbstractValidator<CreateMeaWorkShopDto>
    {
        public CreateMeaWorkShopDtoValidator()  
        {
            Include(new IMeaWorkShopDtoValidator()); 
        }
    }
}
