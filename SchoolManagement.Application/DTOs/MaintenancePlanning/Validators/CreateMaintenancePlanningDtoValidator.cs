using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenancePlanning.Validators
{
    public class CreateMaintenancePlanningDtoValidator : AbstractValidator<CreateMaintenancePlanningDto>
    {
        public CreateMaintenancePlanningDtoValidator()  
        {
            Include(new IMaintenancePlanningDtoValidator()); 
        }
    }
}
