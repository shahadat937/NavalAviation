using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MaintenancePlanning.Validators
{
    public class IMaintenancePlanningDtoValidator : AbstractValidator<IMaintenancePlanningDto>
    {
        public IMaintenancePlanningDtoValidator() 
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
