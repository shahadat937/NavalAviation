using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenancePlanning.Validators
{
    public class UpdateMaintenancePlanningDtoValidator : AbstractValidator<CreateMaintenancePlanningDto>
    {
        public UpdateMaintenancePlanningDtoValidator()
        {
            Include(new IMaintenancePlanningDtoValidator());

            RuleFor(b => b.MaintenancePlanningId).NotNull().WithMessage("{PropertyName} must be present");
        }

        
    }
}

