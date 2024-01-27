using FluentValidation;

namespace SchoolManagement.Application.DTOs.EndLifeTypes.Validators
{
    public class UpdateEndLifeTypeDtoValidator : AbstractValidator<EndLifeTypeDto>
    {
        public UpdateEndLifeTypeDtoValidator() 
        {
            Include(new IEndLifeTypeDtoValidator());

            RuleFor(b => b.EndLifeTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
