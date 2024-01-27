using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseItemName.Validators
{
    public class IGseItemNameDtoValidator : AbstractValidator<IGseItemNameDto>
    {
        public IGseItemNameDtoValidator() 
        {
            RuleFor(b => b.ItemName)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
