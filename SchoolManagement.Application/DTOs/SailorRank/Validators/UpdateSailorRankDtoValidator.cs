using FluentValidation;

namespace SchoolManagement.Application.DTOs.SailorRank.Validators 
{
    public class UpdateSailorRankDtoValidator : AbstractValidator<SailorRankDto>
    {
        public UpdateSailorRankDtoValidator() 
        {
            Include(new ISailorRankDtoValidator());

            RuleFor(b => b.SailorRankId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
