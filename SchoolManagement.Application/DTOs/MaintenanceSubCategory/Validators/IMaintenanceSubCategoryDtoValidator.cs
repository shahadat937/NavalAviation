using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MaintenanceSubCategory.Validators
{
    public class IMaintenanceSubCategoryDtoValidator : AbstractValidator<IMaintenanceSubCategoryDto>
    {
        public IMaintenanceSubCategoryDtoValidator() 
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
