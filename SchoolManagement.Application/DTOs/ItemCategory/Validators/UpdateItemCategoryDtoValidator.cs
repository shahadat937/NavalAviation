using FluentValidation;
using SchoolManagement.Application.DTOs.ItemCategorys;

namespace SchoolManagement.Application.DTOs.ItemCategory.Validators 
{
    public class UpdateItemCategoryDtoValidator : AbstractValidator<ItemCategoryDto>
    {
        public UpdateItemCategoryDtoValidator() 
        {
            Include(new IItemCategoryDtoValidator());

            RuleFor(b => b.ItemCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
