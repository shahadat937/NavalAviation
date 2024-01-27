using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DepartmentName.Validators
{
    public class UpdateDepartmentNameDtoValidator : AbstractValidator<DepartmentNameDto>
    {
        public UpdateDepartmentNameDtoValidator()
        {
            Include(new IDepartmentNameDtoValidator());

            RuleFor(b => b.DepartmentNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

