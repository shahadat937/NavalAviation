using FluentValidation;

namespace SchoolManagement.Application.DTOs.MaintenanceCategory.Validators
{
    public class IMaintenanceCategoryDtoValidator : AbstractValidator<IMaintenanceCategoryDto>
    {
        public IMaintenanceCategoryDtoValidator() 
        {
            RuleFor(b => b.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
