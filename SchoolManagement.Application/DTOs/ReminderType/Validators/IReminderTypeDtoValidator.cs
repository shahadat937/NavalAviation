using FluentValidation;

namespace SchoolManagement.Application.DTOs.ReminderType.Validators
{
    public class IReminderTypeDtoValidator : AbstractValidator<IReminderTypeDto>
    {
        public IReminderTypeDtoValidator() 
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
