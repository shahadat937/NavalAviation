using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.District.Validators
{
    public class UpdateDistrictDtoValidator : AbstractValidator<DistrictDto>
    {
        public UpdateDistrictDtoValidator()
        {
            Include(new IDistrictDtoValidator());

            RuleFor(p => p.DistrictId).NotNull().WithMessage("{PropertyName} must be present");

            RuleFor(p => p.DivisionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
