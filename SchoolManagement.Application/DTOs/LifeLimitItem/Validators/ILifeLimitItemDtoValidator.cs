using FluentValidation;

namespace SchoolManagement.Application.DTOs.LifeLimitItem.Validators
{
    public class ILifeLimitItemDtoValidator : AbstractValidator<ILifeLimitItemDto>
    {
        public ILifeLimitItemDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
