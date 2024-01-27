using FluentValidation;

namespace SchoolManagement.Application.DTOs.ReminderType.Validators
{
    public class CreateReminderTypeDtoValidator : AbstractValidator<CreateReminderTypeDto>
    {
        public CreateReminderTypeDtoValidator()  
        {
            Include(new IReminderTypeDtoValidator()); 
        }
    }
}
