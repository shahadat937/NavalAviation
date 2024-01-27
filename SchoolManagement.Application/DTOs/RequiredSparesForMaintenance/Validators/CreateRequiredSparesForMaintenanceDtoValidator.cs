using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RequiredSparesForMaintenance.Validators
{
    public class CreateRequiredSparesForMaintenanceDtoValidator : AbstractValidator<CreateRequiredSparesForMaintenanceDto>
    {
        public CreateRequiredSparesForMaintenanceDtoValidator()  
        {
            Include(new IRequiredSparesForMaintenanceDtoValidator()); 
        }
    }
}
