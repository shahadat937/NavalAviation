using FluentValidation;

namespace SchoolManagement.Application.DTOs.LifeLimitItemRunningHour.Validators
{
    public class ILifeLimitItemRunningHourDtoValidator : AbstractValidator<ILifeLimitItemRunningHourDto>
    {
        public ILifeLimitItemRunningHourDtoValidator() 
        {
            //RuleFor(b => b.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
