using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseScheduleWorkType.Validators
{
    public class CreateGseScheduleWorkTypeDtoValidator : AbstractValidator<CreateGseScheduleWorkTypeDto>
    {
        public CreateGseScheduleWorkTypeDtoValidator()  
        {
            Include(new IGseScheduleWorkTypeDtoValidator()); 
        }
    }
}
