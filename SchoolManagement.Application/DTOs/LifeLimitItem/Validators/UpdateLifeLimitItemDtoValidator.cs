using FluentValidation;

namespace SchoolManagement.Application.DTOs.LifeLimitItem.Validators
{
    public class UpdateLifeLimitItemDtoValidator : AbstractValidator<LifeLimitItemDto>
    {
        public UpdateLifeLimitItemDtoValidator()
        {
            Include(new ILifeLimitItemDtoValidator());

            RuleFor(b => b.LifeLimitItemId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

