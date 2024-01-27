using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MaintenanceType.Validators
{
    public class IMaintenanceTypeDtoValidator : AbstractValidator<IMaintenanceTypeDto>
    {
        public IMaintenanceTypeDtoValidator() 
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
