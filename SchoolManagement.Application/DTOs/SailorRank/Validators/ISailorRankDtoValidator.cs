
using FluentValidation;
using SchoolManagement.Application.DTOs.SailorRank;

namespace SchoolManagement.Application.DTOs.SailorRank.Validators
{
    public class ISailorRankDtoValidator : AbstractValidator<ISailorRankDto>
    {
        public ISailorRankDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
