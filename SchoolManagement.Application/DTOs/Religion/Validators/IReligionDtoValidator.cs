using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Religion.Validators
{
    public class IReligionDtoValidator : AbstractValidator<IReligionDto>
    {
        public IReligionDtoValidator()
        {
            RuleFor(p => p.ReligionName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            
        }
    }
}
