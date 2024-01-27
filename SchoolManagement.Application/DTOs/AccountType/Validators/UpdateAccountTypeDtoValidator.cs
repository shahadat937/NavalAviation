using FluentValidation;

namespace SchoolManagement.Application.DTOs.AccountType.Validators
{
    public class UpdateAccountTypeDtoValidator : AbstractValidator<AccountTypeDto>
    {
        public UpdateAccountTypeDtoValidator()
        {
            Include(new IAccountTypeDtoValidator());

            RuleFor(b => b.AccountTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

