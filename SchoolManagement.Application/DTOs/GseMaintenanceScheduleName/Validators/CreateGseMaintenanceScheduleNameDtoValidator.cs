using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseMaintenanceScheduleName.Validators
{
    public class CreateGseMaintenanceScheduleNameDtoValidator : AbstractValidator<CreateGseMaintenanceScheduleNameDto>
    {
        public CreateGseMaintenanceScheduleNameDtoValidator()  
        {
            Include(new IGseMaintenanceScheduleNameDtoValidator()); 
        }
    }
}
