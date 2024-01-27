using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.AirCraftName.Validators
{
    public class UpdateAirCraftNameDtoValidator : AbstractValidator<AirCraftNameDto>
    {
        public UpdateAirCraftNameDtoValidator()
        {
            Include(new IAirCraftNameDtoValidator());

            RuleFor(b => b.AirCraftNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

