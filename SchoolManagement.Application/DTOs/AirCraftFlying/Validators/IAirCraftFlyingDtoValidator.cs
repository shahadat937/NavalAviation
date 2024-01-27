using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AirCraftFlying.Validators
{
    public class IAirCraftFlyingDtoValidator : AbstractValidator<IAirCraftFlyingDto>
    {
        public IAirCraftFlyingDtoValidator() 
        {
            //RuleFor(b => b.Name)
                //.NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
