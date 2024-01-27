using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenanceSchedule.Validators
{
    public class CreateMaintenanceScheduleDtoValidator : AbstractValidator<CreateMaintenanceScheduleDto>
    {
        public CreateMaintenanceScheduleDtoValidator()
        {
            Include(new IMaintenanceScheduleDtoValidator());
        }
    }
}
