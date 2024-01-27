
using FluentValidation;

namespace SchoolManagement.Application.DTOs.MeaSquadronState.Validators
{
    public class IMeaSquadronStateDtoValidator : AbstractValidator<IMeaSquadronStateDto>
    {
        public IMeaSquadronStateDtoValidator()
        {
            //RuleFor(b => b.WorkOrderReceived)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
