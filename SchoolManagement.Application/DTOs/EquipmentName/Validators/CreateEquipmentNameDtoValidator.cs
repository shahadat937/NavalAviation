using FluentValidation;

namespace SchoolManagement.Application.DTOs.EquipmentName.Validators
{
    public class CreateEquipmentNameDtoValidator : AbstractValidator<CreateEquipmentNameDto>
    {
        public CreateEquipmentNameDtoValidator()
        {
            Include(new IEquipmentNameDtoValidator());
        }
    }
}
 