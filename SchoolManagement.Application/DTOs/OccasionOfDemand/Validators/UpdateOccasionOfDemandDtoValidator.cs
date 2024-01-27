using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.OccasionOfDemand.Validators
{
    public class UpdateOccasionOfDemandDtoValidator : AbstractValidator<OccasionOfDemandDto>
    {
        public UpdateOccasionOfDemandDtoValidator()
        {
            Include(new IOccasionOfDemandDtoValidator());

            RuleFor(b => b.OccasionOfDemandId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

