using FluentValidation;

namespace SchoolManagement.Application.DTOs.EquipmentName.Validators
{
    public class UpdateEquipmentNameDtoValidator : AbstractValidator<EquipmentNameDto>
    {
        public UpdateEquipmentNameDtoValidator() 
        {
            Include(new IEquipmentNameDtoValidator());

            RuleFor(b => b.EquipmentNameId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
