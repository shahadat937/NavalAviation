
using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandDocs.Validators
{
    public class IDemandDocDtoValidator : AbstractValidator<IDemandDocDto>
    {
        public IDemandDocDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
