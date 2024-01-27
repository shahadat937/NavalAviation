
using FluentValidation;
using SchoolManagement.Application.DTOs.ItemCategorys;

namespace SchoolManagement.Application.DTOs.ItemCategory.Validators
{
    public class IItemCategoryDtoValidator : AbstractValidator<IItemCategoryDto>
    {
        public IItemCategoryDtoValidator()
        { 
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
