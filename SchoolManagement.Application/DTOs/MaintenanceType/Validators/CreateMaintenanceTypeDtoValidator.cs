using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenanceType.Validators
{
    public class CreateMaintenanceTypeDtoValidator : AbstractValidator<CreateMaintenanceTypeDto>
    {
        public CreateMaintenanceTypeDtoValidator()  
        {
            Include(new IMaintenanceTypeDtoValidator()); 
        }
    }
}
