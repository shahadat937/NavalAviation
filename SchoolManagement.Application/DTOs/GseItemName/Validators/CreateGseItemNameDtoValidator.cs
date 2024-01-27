using FluentValidation;

namespace SchoolManagement.Application.DTOs.GseItemName.Validators
{
    public class CreateGseItemNameDtoValidator : AbstractValidator<CreateGseItemNameDto>
    {
        public CreateGseItemNameDtoValidator()  
        {
            Include(new IGseItemNameDtoValidator()); 
        }
    }
}
