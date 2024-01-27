using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory.Validators
{
    public class IDailyAirworthinessFromCategoryDtoValidator : AbstractValidator<IDailyAirworthinessFromCategoryDto>
    {
        public IDailyAirworthinessFromCategoryDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
