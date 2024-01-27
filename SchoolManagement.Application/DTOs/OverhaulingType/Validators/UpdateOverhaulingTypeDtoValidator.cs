using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.OverhaulingType.Validators
{
    public class UpdateOverhaulingTypeDtoValidator : AbstractValidator<OverhaulingTypeDto>
    {
        public UpdateOverhaulingTypeDtoValidator()
        {
            Include(new IOverhaulingTypeDtoValidator());

            RuleFor(b => b.OverhaulingTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

