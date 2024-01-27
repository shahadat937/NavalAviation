using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenancePlanningStatus.Validators 
{
    public class UpdateMaintenancePlanningStatusDtoValidator : AbstractValidator<MaintenancePlanningStatusDto>
    {
        public UpdateMaintenancePlanningStatusDtoValidator() 
        {
            Include(new IMaintenancePlanningStatusDtoValidator());

            RuleFor(b => b.MaintenancePlanningStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
