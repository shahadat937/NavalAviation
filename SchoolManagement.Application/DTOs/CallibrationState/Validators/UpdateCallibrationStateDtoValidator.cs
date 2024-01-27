using FluentValidation;

namespace SchoolManagement.Application.DTOs.CallibrationState.Validators
{
    public class UpdateCallibrationStateDtoValidator : AbstractValidator<CallibrationStateDto>
    {
        public UpdateCallibrationStateDtoValidator() 
        {
            Include(new ICallibrationStateDtoValidator());

            RuleFor(b => b.CallibrationStateId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
