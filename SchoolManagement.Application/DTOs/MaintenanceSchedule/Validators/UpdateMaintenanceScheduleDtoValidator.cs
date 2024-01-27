using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenanceSchedule.Validators
{
    public class UpdateMaintenanceScheduleDtoValidator : AbstractValidator<CreateMaintenanceScheduleDto>
    {
        public UpdateMaintenanceScheduleDtoValidator()
        {
            Include(new IMaintenanceScheduleDtoValidator());

            //RuleFor(b => b.MaintenanceScheduleId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

