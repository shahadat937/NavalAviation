using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseMaintenanceScheduleName.Validators
{
    public class UpdateGseMaintenanceScheduleNameDtoValidator : AbstractValidator<GseMaintenanceScheduleNameDto>
    {
        public UpdateGseMaintenanceScheduleNameDtoValidator()
        {
            Include(new IGseMaintenanceScheduleNameDtoValidator());

            RuleFor(b => b.GseMaintenanceScheduleNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

