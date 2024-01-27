
using FluentValidation;

namespace SchoolManagement.Application.DTOs.ItemStatuses.Validators
{
    public class IItemStatusDtoValidator : AbstractValidator<IItemStatusDto>
    {
        public IItemStatusDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
