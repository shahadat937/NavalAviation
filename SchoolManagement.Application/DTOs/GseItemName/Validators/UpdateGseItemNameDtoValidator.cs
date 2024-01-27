using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseItemName.Validators
{
    public class UpdateGseItemNameDtoValidator : AbstractValidator<GseItemNameDto>
    {
        public UpdateGseItemNameDtoValidator()
        {
            Include(new IGseItemNameDtoValidator());

            RuleFor(b => b.GseItemNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

