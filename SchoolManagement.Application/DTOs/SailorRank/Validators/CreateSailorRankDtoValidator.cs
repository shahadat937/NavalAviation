using FluentValidation;

namespace SchoolManagement.Application.DTOs.SailorRank.Validators 
{
    public class CreateSailorRankDtoValidator : AbstractValidator<CreateSailorRankDto>
    {
        public CreateSailorRankDtoValidator()
        {
            Include(new ISailorRankDtoValidator());
        }
    }
}
