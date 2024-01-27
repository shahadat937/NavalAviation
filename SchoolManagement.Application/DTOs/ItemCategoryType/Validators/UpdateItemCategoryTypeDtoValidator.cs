using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ItemCategoryType.Validators
{
    public class UpdateItemCategoryTypeDtoValidator : AbstractValidator<ItemCategoryTypeDto>
    {
        public UpdateItemCategoryTypeDtoValidator()
        {
            Include(new IItemCategoryTypeDtoValidator());

            RuleFor(b => b.ItemCategoryTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

