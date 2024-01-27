
using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandCompleteStatuses.Validators
{
    public class IDemandCompleteStatusDtoValidator : AbstractValidator<IDemandCompleteStatusDto>
    {
        public IDemandCompleteStatusDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
