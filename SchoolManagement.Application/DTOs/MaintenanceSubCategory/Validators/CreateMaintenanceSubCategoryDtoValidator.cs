using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenanceSubCategory.Validators
{
    public class CreateMaintenanceSubCategoryDtoValidator : AbstractValidator<CreateMaintenanceSubCategoryDto>
    {
        public CreateMaintenanceSubCategoryDtoValidator()  
        {
            Include(new IMaintenanceSubCategoryDtoValidator()); 
        }
    }
}
