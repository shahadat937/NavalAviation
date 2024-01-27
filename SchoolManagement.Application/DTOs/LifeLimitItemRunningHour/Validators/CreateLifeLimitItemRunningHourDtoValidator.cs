using FluentValidation;

namespace SchoolManagement.Application.DTOs.LifeLimitItemRunningHour.Validators
{
    public class CreateLifeLimitItemRunningHourDtoValidator : AbstractValidator<CreateLifeLimitItemRunningHourDto>
    {
        public CreateLifeLimitItemRunningHourDtoValidator()  
        {
            Include(new ILifeLimitItemRunningHourDtoValidator()); 
        }
    }
}
