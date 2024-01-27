using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseMaintenance.Validators
{
    public class UpdateGseMaintenanceDtoValidator : AbstractValidator<GseMaintenanceDto>
    {
        public UpdateGseMaintenanceDtoValidator()
        {
            Include(new IGseMaintenanceDtoValidator());

            RuleFor(b => b.GseMaintenanceId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

