using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenenceState.Validators
{
    public class CreateMaintenenceStateDtoValidator : AbstractValidator<CreateMaintenenceStateDto>
    {
        public CreateMaintenenceStateDtoValidator()
        {
            Include(new IMaintenenceStateDtoValidator());
        }
    }
}
