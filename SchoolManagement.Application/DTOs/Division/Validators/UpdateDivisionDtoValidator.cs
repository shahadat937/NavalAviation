using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Division.Validators
{
    public class UpdateDivisionDtoValidator : AbstractValidator<DivisionDto>
    {
        public UpdateDivisionDtoValidator()
        {
            Include(new IDivisionDtoValidator());

            RuleFor(p => p.DivisionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
