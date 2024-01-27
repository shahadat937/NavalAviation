using FluentValidation;

namespace SchoolManagement.Application.DTOs.Denos.Validators
{
    public class CreateDenoDtoValidator : AbstractValidator<CreateDenoDto>
    {
        public CreateDenoDtoValidator()
        {
            Include(new IDenoDtoValidator());
        }
    }
}
 