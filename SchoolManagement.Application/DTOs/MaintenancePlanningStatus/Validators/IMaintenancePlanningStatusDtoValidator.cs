
using FluentValidation;
using SchoolManagement.Application.DTOs.MaintenancePlanningStatus;

namespace SchoolManagement.Application.DTOs.MaintenancePlanningStatus.Validators
{
    public class IMaintenancePlanningStatusDtoValidator : AbstractValidator<IMaintenancePlanningStatusDto>
    {
        public IMaintenancePlanningStatusDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
