using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseMaintenance.Validators
{
    public class CreateGseMaintenanceDtoValidator : AbstractValidator<CreateGseMaintenanceDto>
    {
        public CreateGseMaintenanceDtoValidator()  
        {
            Include(new IGseMaintenanceDtoValidator()); 
        }
    }
}
