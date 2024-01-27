using FluentValidation;

namespace SchoolManagement.Application.DTOs.Acceptances.Validators
{
    public class UpdateAcceptanceDtoValidator : AbstractValidator<CreateAcceptanceDto>
    {
        public UpdateAcceptanceDtoValidator() 
        {
            Include(new IAcceptanceDtoValidator());

            RuleFor(b => b.AcceptanceId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
