
using FluentValidation;

namespace SchoolManagement.Application.DTOs.PreviousItemStore.Validators
{
    public class IPreviousItemStoreDtoValidator : AbstractValidator<IPreviousItemStoreDto>
    {
        public IPreviousItemStoreDtoValidator()
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
