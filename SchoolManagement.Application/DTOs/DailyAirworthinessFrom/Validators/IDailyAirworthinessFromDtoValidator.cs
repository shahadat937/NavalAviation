using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DailyAirworthinessFrom.Validators
{
    public class IDailyAirworthinessFromDtoValidator : AbstractValidator<IDailyAirworthinessFromDto>
    {
        public IDailyAirworthinessFromDtoValidator() 
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
