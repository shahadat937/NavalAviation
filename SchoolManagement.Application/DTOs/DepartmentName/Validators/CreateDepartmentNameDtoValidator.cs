using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DepartmentName.Validators
{
    public class CreateDepartmentNameDtoValidator : AbstractValidator<CreateDepartmentNameDto>
    {
        public CreateDepartmentNameDtoValidator()  
        {
            Include(new IDepartmentNameDtoValidator()); 
        }
    }
}
