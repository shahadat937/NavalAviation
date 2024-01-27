using FluentValidation;

namespace SchoolManagement.Application.DTOs.ConditionOfItems.Validators
{
    public class UpdateConditionOfItemDtoValidator : AbstractValidator<ConditionOfItemDto>
    {
        public UpdateConditionOfItemDtoValidator() 
        {
            Include(new IConditionOfItemDtoValidator());

            RuleFor(b => b.ConditionOfItemId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
