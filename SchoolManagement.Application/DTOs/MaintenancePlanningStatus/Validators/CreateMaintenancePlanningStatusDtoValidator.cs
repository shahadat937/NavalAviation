using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenancePlanningStatus.Validators 
{
    public class CreateMaintenancePlanningStatusDtoValidator : AbstractValidator<CreateMaintenancePlanningStatusDto>
    {
        public CreateMaintenancePlanningStatusDtoValidator()
        {
            Include(new IMaintenancePlanningStatusDtoValidator());
        }
    }
}
 