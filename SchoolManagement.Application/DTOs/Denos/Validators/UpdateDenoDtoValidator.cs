using FluentValidation;

namespace SchoolManagement.Application.DTOs.Denos.Validators
{
    public class UpdateDenoDtoValidator : AbstractValidator<DenoDto>
    {
        public UpdateDenoDtoValidator() 
        {
            Include(new IDenoDtoValidator());

            RuleFor(b => b.DenoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
