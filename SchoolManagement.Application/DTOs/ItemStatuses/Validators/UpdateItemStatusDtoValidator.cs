using FluentValidation;

namespace SchoolManagement.Application.DTOs.ItemStatuses.Validators
{
    public class UpdateItemStatusDtoValidator : AbstractValidator<ItemStatusDto>
    {
        public UpdateItemStatusDtoValidator() 
        {
            Include(new IItemStatusDtoValidator());

            RuleFor(b => b.ItemStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
