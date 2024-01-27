using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseScheduleWorkType.Validators
{
    public class UpdateGseScheduleWorkTypeDtoValidator : AbstractValidator<GseScheduleWorkTypeDto>
    {
        public UpdateGseScheduleWorkTypeDtoValidator()
        {
            Include(new IGseScheduleWorkTypeDtoValidator());

            RuleFor(b => b.GseScheduleWorkTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

