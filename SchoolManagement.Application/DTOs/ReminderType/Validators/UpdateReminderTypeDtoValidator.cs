using FluentValidation;

namespace SchoolManagement.Application.DTOs.ReminderType.Validators
{
    public class UpdateReminderTypeDtoValidator : AbstractValidator<ReminderTypeDto>
    {
        public UpdateReminderTypeDtoValidator()
        {
            Include(new IReminderTypeDtoValidator());

            RuleFor(b => b.ReminderTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

