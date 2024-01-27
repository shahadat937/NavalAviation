using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseMaintenanceScheduleName.Validators
{
    public class IGseMaintenanceScheduleNameDtoValidator : AbstractValidator<IGseMaintenanceScheduleNameDto>
    {
        public IGseMaintenanceScheduleNameDtoValidator() 
        {
            RuleFor(b => b.ScheduleName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
