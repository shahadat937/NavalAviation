using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Survey.Validators
{
    public class ISurveyDtoValidator : AbstractValidator<ISurveyDto>
    {
        public ISurveyDtoValidator() 
        {
            RuleFor(b => b.SurveyNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
