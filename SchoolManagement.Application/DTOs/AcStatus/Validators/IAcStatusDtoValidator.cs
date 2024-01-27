
using FluentValidation;
using SchoolManagement.Application.DTOs.AcStatuss;

namespace SchoolManagement.Application.DTOs.AcStatus.Validators
{
    public class IAcStatusDtoValidator : AbstractValidator<IAcStatusDto>
    {
        public IAcStatusDtoValidator()
        {
            RuleFor(b => b.ExcepRelease)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
