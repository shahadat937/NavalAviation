using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Survey.Validators
{
    public class UpdateSurveyDtoValidator : AbstractValidator<SurveyDto>
    {
        public UpdateSurveyDtoValidator()
        {
            Include(new ISurveyDtoValidator());

            RuleFor(b => b.SurveyId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

