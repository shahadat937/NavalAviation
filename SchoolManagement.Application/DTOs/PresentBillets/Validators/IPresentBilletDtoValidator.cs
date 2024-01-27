
using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentBillets.Validators
{
    public class IPresentBilletDtoValidator : AbstractValidator<IPresentBilletDto>
    {
        public IPresentBilletDtoValidator()
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
