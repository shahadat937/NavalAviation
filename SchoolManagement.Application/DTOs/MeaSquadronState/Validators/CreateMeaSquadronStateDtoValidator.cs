using FluentValidation;

namespace SchoolManagement.Application.DTOs.MeaSquadronState.Validators
{
    public class CreateMeaSquadronStateDtoValidator : AbstractValidator<CreateMeaSquadronStateDto>
    {
        public CreateMeaSquadronStateDtoValidator()
        {
            Include(new IMeaSquadronStateDtoValidator());
        }
    }
}
 