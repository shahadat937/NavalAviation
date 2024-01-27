using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ItemInspection.Validators
{
    public class UpdateItemInspectionDtoValidator : AbstractValidator<ItemInspectionDto>
    {
        public UpdateItemInspectionDtoValidator()
        {
            Include(new IItemInspectionDtoValidator());

            RuleFor(b => b.ItemInspectionId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

