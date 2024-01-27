using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenanceCategory.Validators
{
    public class UpdateMaintenanceCategoryDtoValidator : AbstractValidator<MaintenanceCategoryDto>
    {
        public UpdateMaintenanceCategoryDtoValidator()
        {
            Include(new IMaintenanceCategoryDtoValidator());

            RuleFor(b => b.MaintenanceCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

