using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandStatus.Validators
{
    public class CreateDemandStatusDtoValidator : AbstractValidator<CreateDemandStatusDto>
    {
        public CreateDemandStatusDtoValidator()  
        {
            Include(new IDemandStatusDtoValidator()); 
        }
    }
}
