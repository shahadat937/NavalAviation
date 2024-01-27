using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandAuthority.Validators
{
    public class CreateDemandAuthorityDtoValidator : AbstractValidator<CreateDemandAuthorityDto>
    {
        public CreateDemandAuthorityDtoValidator()
        { 
            Include(new IDemandAuthorityDtoValidator());
        }
    }
}
 