using FluentValidation;

namespace SchoolManagement.Application.DTOs.EndLifeTypes.Validators
{
    public class CreateEndLifeTypeDtoValidator : AbstractValidator<CreateEndLifeTypeDto>
    {
        public CreateEndLifeTypeDtoValidator()
        {
            Include(new IEndLifeTypeDtoValidator());
        }
    }
}
 