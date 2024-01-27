using FluentValidation;

namespace SchoolManagement.Application.DTOs.ItemTypes.Validators
{
    public class UpdateItemTypeDtoValidator : AbstractValidator<ItemTypeDto>
    {
        public UpdateItemTypeDtoValidator() 
        {
            Include(new IItemTypeDtoValidator());

            RuleFor(b => b.ItemTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
