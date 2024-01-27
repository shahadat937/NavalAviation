using FluentValidation;

namespace SchoolManagement.Application.DTOs.ItemTypes.Validators
{
    public class CreateItemTypeDtoValidator : AbstractValidator<CreateItemTypeDto>
    {
        public CreateItemTypeDtoValidator()
        {
            Include(new IItemTypeDtoValidator());
        }
    }
}
 