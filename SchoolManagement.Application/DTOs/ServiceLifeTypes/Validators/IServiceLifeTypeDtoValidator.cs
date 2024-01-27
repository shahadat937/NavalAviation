using FluentValidation;

namespace SchoolManagement.Application.DTOs.ServiceLifeTypes.Validators
{
    public class IServiceLifeTypeDtoValidator : AbstractValidator<IServiceLifeTypeDto>
    {
        public IServiceLifeTypeDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
