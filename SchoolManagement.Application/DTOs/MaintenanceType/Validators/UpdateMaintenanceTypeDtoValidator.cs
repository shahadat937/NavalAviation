using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MaintenanceType.Validators
{
    public class UpdateMaintenanceTypeDtoValidator : AbstractValidator<MaintenanceTypeDto>
    {
        public UpdateMaintenanceTypeDtoValidator()
        {
            Include(new IMaintenanceTypeDtoValidator());

            //RuleFor(b => b.MaintenanceTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

