
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Demands.Validators
{
    public class IDemandDtoValidator : AbstractValidator<IDemandDto>
    {
        public IDemandDtoValidator()
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
