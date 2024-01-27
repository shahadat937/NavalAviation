
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ConditionOfItems.Validators
{
    public class IConditionOfItemDtoValidator : AbstractValidator<IConditionOfItemDto>
    {
        public IConditionOfItemDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
