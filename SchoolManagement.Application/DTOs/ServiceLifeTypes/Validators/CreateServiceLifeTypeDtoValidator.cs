using FluentValidation;

namespace SchoolManagement.Application.DTOs.ServiceLifeTypes.Validators
{
    public class CreateServiceLifeTypeDtoValidator : AbstractValidator<CreateServiceLifeTypeDto>
    {
        public CreateServiceLifeTypeDtoValidator()
        {
            Include(new IServiceLifeTypeDtoValidator());
        }
    }
}
 