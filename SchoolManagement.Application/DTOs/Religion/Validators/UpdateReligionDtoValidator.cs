using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Religion.Validators
{
    public class UpdateReligionDtoValidator : AbstractValidator<ReligionDto>
    {
        public UpdateReligionDtoValidator()
        {
            Include(new IReligionDtoValidator());

            RuleFor(p => p.ReligionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
