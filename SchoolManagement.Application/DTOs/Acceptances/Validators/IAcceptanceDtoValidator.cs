
using FluentValidation;

namespace SchoolManagement.Application.DTOs.Acceptances.Validators
{
    public class IAcceptanceDtoValidator : AbstractValidator<IAcceptanceDto>
    { 
        public IAcceptanceDtoValidator()
        {
            //RuleFor(b => b.Model)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
