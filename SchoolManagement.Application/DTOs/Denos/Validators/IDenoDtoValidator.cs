
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Denos.Validators
{
    public class IDenoDtoValidator : AbstractValidator<IDenoDto>
    {
        public IDenoDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
