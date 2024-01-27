using FluentValidation;

namespace SchoolManagement.Application.DTOs.AccountType.Validators
{
    public class IAccountTypeDtoValidator : AbstractValidator<IAccountTypeDto>
    {
        public IAccountTypeDtoValidator() 
        {
            RuleFor(b => b.AccoutType)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
