using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.MaintenanceSubCategory.Validators
{
    public class UpdateMaintenanceSubCategoryDtoValidator : AbstractValidator<MaintenanceSubCategoryDto>
    {
        public UpdateMaintenanceSubCategoryDtoValidator()
        {
            Include(new IMaintenanceSubCategoryDtoValidator());

            //RuleFor(b => b.MaintenanceSubCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

