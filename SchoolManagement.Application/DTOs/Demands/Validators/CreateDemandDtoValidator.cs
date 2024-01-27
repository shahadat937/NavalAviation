using FluentValidation;

namespace SchoolManagement.Application.DTOs.Demands.Validators
{
    public class CreateDemandDtoValidator : AbstractValidator<CreateDemandDto>
    {
        public CreateDemandDtoValidator()
        {
            Include(new IDemandDtoValidator());
        }
    }
}
 