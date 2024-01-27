using FluentValidation;

namespace SchoolManagement.Application.DTOs.ServiceLifeTypes.Validators
{
    public class UpdateServiceLifeTypeDtoValidator : AbstractValidator<ServiceLifeTypeDto>
    {
        public UpdateServiceLifeTypeDtoValidator() 
        {
            Include(new IServiceLifeTypeDtoValidator());

            RuleFor(b => b.ServiceLifeTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
