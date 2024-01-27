
using FluentValidation;

namespace SchoolManagement.Application.DTOs.CallibrationState.Validators
{
    public class ICallibrationStateDtoValidator : AbstractValidator<ICallibrationStateDto>
    {
        public ICallibrationStateDtoValidator()
        {
            RuleFor(b => b.ItemName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
