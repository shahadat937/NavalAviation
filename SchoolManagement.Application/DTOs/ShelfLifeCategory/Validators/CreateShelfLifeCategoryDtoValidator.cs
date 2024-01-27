using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ShelfLifeCategory.Validators
{
    public class CreateShelfLifeCategoryDtoValidator : AbstractValidator<CreateShelfLifeCategoryDto>
    {
        public CreateShelfLifeCategoryDtoValidator()  
        {
            Include(new IShelfLifeCategoryDtoValidator()); 
        }
    }
}
