using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.OccasionOfDemand.Validators
{
    public class IOccasionOfDemandDtoValidator : AbstractValidator<IOccasionOfDemandDto>
    {
        public IOccasionOfDemandDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
