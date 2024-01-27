using FluentValidation;

namespace SchoolManagement.Application.DTOs.LifeLimitItem.Validators
{
    public class CreateLifeLimitItemDtoValidator : AbstractValidator<CreateLifeLimitItemDto>
    {
        public CreateLifeLimitItemDtoValidator()  
        {
            Include(new ILifeLimitItemDtoValidator()); 
        }
    }
}
