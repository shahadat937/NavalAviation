using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentState.Validators
{
    public class CreatePresentStateDtoValidator : AbstractValidator<CreatePresentStateDto>
    {
        public CreatePresentStateDtoValidator()
        {
            Include(new IPresentStateDtoValidator());
        }
    }
}
 