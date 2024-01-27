
using FluentValidation;

namespace SchoolManagement.Application.DTOs.EquipmentName.Validators
{
    public class IEquipmentNameDtoValidator : AbstractValidator<IEquipmentNameDto>
    {
        public IEquipmentNameDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
