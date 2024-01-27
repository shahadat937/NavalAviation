
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ItemTypes.Validators
{
    public class IItemTypeDtoValidator : AbstractValidator<IItemTypeDto>
    {
        public IItemTypeDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
