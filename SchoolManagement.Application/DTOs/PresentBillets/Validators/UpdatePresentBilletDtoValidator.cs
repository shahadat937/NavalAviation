using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentBillets.Validators
{
    public class UpdatePresentBilletDtoValidator : AbstractValidator<PresentBilletDto>
    {
        public UpdatePresentBilletDtoValidator() 
        {
            Include(new IPresentBilletDtoValidator());

            RuleFor(b => b.PresentBilletId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
