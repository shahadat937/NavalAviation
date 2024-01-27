using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenanceCategory.Validators
{
    public class CreateMaintenanceCategoryDtoValidator : AbstractValidator<CreateMaintenanceCategoryDto>
    {
        public CreateMaintenanceCategoryDtoValidator()  
        {
            Include(new IMaintenanceCategoryDtoValidator()); 
        }
    }
}
