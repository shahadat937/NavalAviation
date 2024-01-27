using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenenceState.Validators
{
    public class UpdateMaintenenceStateDtoValidator : AbstractValidator<MaintenenceStateDto>
    {
        public UpdateMaintenenceStateDtoValidator() 
        {
            Include(new IMaintenenceStateDtoValidator());

            RuleFor(b => b.MaintenenceStateId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
