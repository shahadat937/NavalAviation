using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DemandType.Validators
{
    public class UpdateDemandTypeDtoValidator : AbstractValidator<DemandTypeDto>
    {
        public UpdateDemandTypeDtoValidator()
        {
            Include(new IDemandTypeDtoValidator());

            RuleFor(b => b.DemandTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

