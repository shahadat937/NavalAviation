using FluentValidation;

namespace SchoolManagement.Application.DTOs.UserTransferBackups.Validators
{
    public class UpdateUserTransferBackupDtoValidator : AbstractValidator<UserTransferBackupDto>
    {
        public UpdateUserTransferBackupDtoValidator() 
        {
            //Include(new IUserTransferBackupDtoValidator());

            //RuleFor(b => b.UserTransferBackupId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
