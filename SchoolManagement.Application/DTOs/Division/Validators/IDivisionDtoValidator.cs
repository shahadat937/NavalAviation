using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Division.Validators
{
    public class IDivisionDtoValidator : AbstractValidator<IDivisionDto>
    {
        public IDivisionDtoValidator()
        {
            RuleFor(p => p.DivisionName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

           
        }
    }
}
