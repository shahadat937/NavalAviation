
using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentState.Validators
{
    public class IPresentStateDtoValidator : AbstractValidator<IPresentStateDto>
    {
        public IPresentStateDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
