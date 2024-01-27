using FluentValidation;
using SchoolManagement.Application.DTOs.Procurement;

namespace SchoolManagement.Application.DTOs.Procurement.Validators
{
    public class CreateProcurementDtoValidator : AbstractValidator<CreateProcurementDto>
    {
        public CreateProcurementDtoValidator()
        {
            Include(new IProcurementDtoValidator());
        }
    }
} 
 