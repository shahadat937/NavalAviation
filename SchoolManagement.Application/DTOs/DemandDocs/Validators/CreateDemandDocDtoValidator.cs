using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandDocs.Validators
{
    public class CreateDemandDocDtoValidator : AbstractValidator<CreateDemandDocDto>
    {
        public CreateDemandDocDtoValidator()
        {
            Include(new IDemandDocDtoValidator());
        }
    }
}
 