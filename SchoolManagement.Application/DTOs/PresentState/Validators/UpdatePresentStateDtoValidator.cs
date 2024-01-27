using FluentValidation;

namespace SchoolManagement.Application.DTOs.PresentState.Validators
{
    public class UpdatePresentStateDtoValidator : AbstractValidator<PresentStateDto>
    {
        public UpdatePresentStateDtoValidator() 
        {
            Include(new IPresentStateDtoValidator());

            RuleFor(b => b.PresentStateId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
