using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ShelfLifeCategory.Validators
{
    public class UpdateShelfLifeCategoryDtoValidator : AbstractValidator<ShelfLifeCategoryDto>
    {
        public UpdateShelfLifeCategoryDtoValidator()
        {
            Include(new IShelfLifeCategoryDtoValidator());

            RuleFor(b => b.ShelfLifeCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

