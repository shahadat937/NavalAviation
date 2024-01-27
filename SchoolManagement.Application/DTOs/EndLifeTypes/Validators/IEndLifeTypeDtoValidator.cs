
using FluentValidation;

namespace SchoolManagement.Application.DTOs.EndLifeTypes.Validators
{
    public class IEndLifeTypeDtoValidator : AbstractValidator<IEndLifeTypeDto>
    {
        public IEndLifeTypeDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
