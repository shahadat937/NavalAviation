using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ItemCategoryType.Validators
{
    public class CreateItemCategoryTypeDtoValidator : AbstractValidator<CreateItemCategoryTypeDto>
    {
        public CreateItemCategoryTypeDtoValidator()  
        {
            Include(new IItemCategoryTypeDtoValidator()); 
        }
    }
}
