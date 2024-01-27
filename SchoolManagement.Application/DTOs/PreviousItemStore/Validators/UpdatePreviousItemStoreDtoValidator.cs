using FluentValidation;

namespace SchoolManagement.Application.DTOs.PreviousItemStore.Validators
{
    public class UpdatePreviousItemStoreDtoValidator : AbstractValidator<PreviousItemStoreDto>
    {
        public UpdatePreviousItemStoreDtoValidator() 
        {
            Include(new IPreviousItemStoreDtoValidator());

            //RuleFor(b => b.PreviousItemStoreId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
