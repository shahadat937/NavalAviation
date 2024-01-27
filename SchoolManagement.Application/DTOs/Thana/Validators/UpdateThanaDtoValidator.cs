using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.Thana.Validators
{
    public class UpdateThanaDtoValidator : AbstractValidator<ThanaDto>
    {
        public UpdateThanaDtoValidator()
        {
            Include(new IThanaDtoValidator());

            RuleFor(p => p.DistrictId).NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(p => p.ThanaId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
