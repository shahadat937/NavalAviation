using FluentValidation;

namespace SchoolManagement.Application.DTOs.UserTransferBackups.Validators
{
    public class CreateUserTransferBackupDtoValidator : AbstractValidator<CreateUserTransferBackupDto>
    {
        public CreateUserTransferBackupDtoValidator()
        {
            Include(new IUserTransferBackupDtoValidator());
        }
    }
}
