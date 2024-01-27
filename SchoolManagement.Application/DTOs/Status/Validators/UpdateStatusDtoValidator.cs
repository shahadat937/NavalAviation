using FluentValidation;

namespace SchoolManagement.Application.DTOs.Status.Validators 
{
    public class UpdateStatusDtoValidator : AbstractValidator<StatusDto>
    {
        public UpdateStatusDtoValidator() 
        {
            Include(new IStatusDtoValidator());

            RuleFor(b => b.StatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
