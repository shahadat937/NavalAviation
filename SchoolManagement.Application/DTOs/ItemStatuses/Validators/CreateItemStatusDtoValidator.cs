using FluentValidation;

namespace SchoolManagement.Application.DTOs.ItemStatuses.Validators
{
    public class CreateItemStatusDtoValidator : AbstractValidator<CreateItemStatusDto>
    {
        public CreateItemStatusDtoValidator()
        {
            Include(new IItemStatusDtoValidator());
        }
    }
}
 