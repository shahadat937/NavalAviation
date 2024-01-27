using FluentValidation;

namespace SchoolManagement.Application.DTOs.LifeLimitItemRunningHour.Validators
{
    public class UpdateLifeLimitItemRunningHourDtoValidator : AbstractValidator<LifeLimitItemRunningHourDto>
    {
        public UpdateLifeLimitItemRunningHourDtoValidator()
        {
            Include(new ILifeLimitItemRunningHourDtoValidator());

            RuleFor(b => b.LifeLimitItemRunningHourId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

