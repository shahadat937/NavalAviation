using FluentValidation;

namespace SchoolManagement.Application.DTOs.ConditionOfItems.Validators
{
    public class CreateConditionOfItemDtoValidator : AbstractValidator<CreateConditionOfItemDto>
    {
        public CreateConditionOfItemDtoValidator()
        {
            Include(new IConditionOfItemDtoValidator());
        }
    }
}
 