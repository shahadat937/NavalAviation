using FluentValidation;

namespace SchoolManagement.Application.DTOs.PreviousItemStore.Validators
{
    public class CreatePreviousItemStoreDtoValidator : AbstractValidator<CreatePreviousItemStoreDto>
    {
        public CreatePreviousItemStoreDtoValidator()
        {
           // Include(new IPreviousItemStoreDtoValidator());
        }
    }
}
 