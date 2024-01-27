
using FluentValidation;

namespace SchoolManagement.Application.DTOs.UserTransferBackups.Validators
{
    public class IUserTransferBackupDtoValidator : AbstractValidator<IUserTransferBackupDto>
    {
        public IUserTransferBackupDtoValidator()
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
