using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentBillets.Validators
{
    public class CreatePresentBilletDtoValidator : AbstractValidator<CreatePresentBilletDto>
    {
        public CreatePresentBilletDtoValidator()
        {
            Include(new IPresentBilletDtoValidator());
        }
    }
}
