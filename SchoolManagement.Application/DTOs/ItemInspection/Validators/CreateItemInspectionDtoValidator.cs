using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ItemInspection.Validators
{
    public class CreateItemInspectionDtoValidator : AbstractValidator<CreateItemInspectionDto>
    {
        public CreateItemInspectionDtoValidator()  
        {
            Include(new IItemInspectionDtoValidator()); 
        }
    }
}
