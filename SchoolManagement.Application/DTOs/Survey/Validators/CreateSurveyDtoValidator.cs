using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Survey.Validators
{
    public class CreateSurveyDtoValidator : AbstractValidator<CreateSurveyDto>
    {
        public CreateSurveyDtoValidator()  
        {
            Include(new ISurveyDtoValidator()); 
        }
    }
}
