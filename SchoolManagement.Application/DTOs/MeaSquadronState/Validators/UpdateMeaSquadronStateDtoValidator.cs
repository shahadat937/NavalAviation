using FluentValidation;

namespace SchoolManagement.Application.DTOs.MeaSquadronState.Validators
{
    public class UpdateMeaSquadronStateDtoValidator : AbstractValidator<MeaSquadronStateDto>
    {
        public UpdateMeaSquadronStateDtoValidator() 
        {
            Include(new IMeaSquadronStateDtoValidator());

            RuleFor(b => b.MeaSquadronStateId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
