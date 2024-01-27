using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseScheduleWorkType.Validators
{
    public class IGseScheduleWorkTypeDtoValidator : AbstractValidator<IGseScheduleWorkTypeDto>
    {
        public IGseScheduleWorkTypeDtoValidator() 
        {
            RuleFor(b => b.ScheduleWorkName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
