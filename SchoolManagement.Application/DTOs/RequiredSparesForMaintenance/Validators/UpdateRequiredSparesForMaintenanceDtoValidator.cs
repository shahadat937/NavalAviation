using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.RequiredSparesForMaintenance.Validators
{
    public class UpdateRequiredSparesForMaintenanceDtoValidator : AbstractValidator<RequiredSparesForMaintenanceDto>
    {
        public UpdateRequiredSparesForMaintenanceDtoValidator()
        {
            Include(new IRequiredSparesForMaintenanceDtoValidator());

            RuleFor(b => b.RequiredSparesForMaintenanceId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

