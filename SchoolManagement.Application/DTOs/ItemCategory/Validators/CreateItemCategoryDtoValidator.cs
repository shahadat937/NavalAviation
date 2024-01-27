using FluentValidation;
using SchoolManagement.Application.DTOs.ItemCategorys;

namespace SchoolManagement.Application.DTOs.ItemCategory.Validators
{
    public class CreateItemCategoryDtoValidator : AbstractValidator<CreateItemCategoryDto>
    {
        public CreateItemCategoryDtoValidator()
        { 
            Include(new IItemCategoryDtoValidator());
        }
    }
}
 