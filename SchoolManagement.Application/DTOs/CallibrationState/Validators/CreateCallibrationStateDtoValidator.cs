using FluentValidation;

namespace SchoolManagement.Application.DTOs.CallibrationState.Validators
{
    public class CreateCallibrationStateDtoValidator : AbstractValidator<CreateCallibrationStateDto>
    {
        public CreateCallibrationStateDtoValidator()
        {
            Include(new ICallibrationStateDtoValidator());
        }
    }
}
 