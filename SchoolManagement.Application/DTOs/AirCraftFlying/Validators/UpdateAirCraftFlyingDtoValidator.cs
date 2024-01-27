using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AirCraftFlying.Validators
{
    public class UpdateAirCraftFlyingDtoValidator : AbstractValidator<AirCraftFlyingDto>
    {
        public UpdateAirCraftFlyingDtoValidator()
        {
            Include(new IAirCraftFlyingDtoValidator());

            RuleFor(b => b.AirCraftFlyingId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

