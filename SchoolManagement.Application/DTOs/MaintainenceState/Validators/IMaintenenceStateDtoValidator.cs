
using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenenceState.Validators
{
    public class IMaintenenceStateDtoValidator : AbstractValidator<IMaintenenceStateDto>
    {
        public IMaintenenceStateDtoValidator()
        {
            RuleFor(b => b.ItemName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
