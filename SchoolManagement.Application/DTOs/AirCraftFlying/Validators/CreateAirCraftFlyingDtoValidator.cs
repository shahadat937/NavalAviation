using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.AirCraftFlying.Validators
{
    public class CreateAirCraftFlyingDtoValidator : AbstractValidator<CreateAirCraftFlyingDto>
    {
        public CreateAirCraftFlyingDtoValidator()  
        {
            Include(new IAirCraftFlyingDtoValidator()); 
        }
    }
}
