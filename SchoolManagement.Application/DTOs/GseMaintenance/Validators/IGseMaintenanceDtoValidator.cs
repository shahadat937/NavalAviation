using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseMaintenance.Validators
{
    public class IGseMaintenanceDtoValidator : AbstractValidator<IGseMaintenanceDto>
    {
        public IGseMaintenanceDtoValidator() 
        {
            //RuleFor(b => b.CategoryName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
