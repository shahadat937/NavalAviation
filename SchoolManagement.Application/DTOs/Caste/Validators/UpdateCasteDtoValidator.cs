using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.Caste.Validators
{
    public class UpdateCasteDtoValidator : AbstractValidator<CasteDto>
    {
        public UpdateCasteDtoValidator()
        {
            Include(new ICasteDtoValidator());

            RuleFor(p => p.ReligionId).NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(p => p.CasteId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
