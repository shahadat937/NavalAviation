
using FluentValidation;
using SchoolManagement.Application.DTOs.Status;

namespace SchoolManagement.Application.DTOs.Status.Validators
{
    public class IStatusDtoValidator : AbstractValidator<IStatusDto>
    {
        public IStatusDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
