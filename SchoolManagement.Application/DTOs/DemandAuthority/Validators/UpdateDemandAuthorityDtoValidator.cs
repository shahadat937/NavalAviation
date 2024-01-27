using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandAuthority.Validators
{
    public class UpdateDemandAuthorityDtoValidator : AbstractValidator<DemandAuthorityDto>
    {
        public UpdateDemandAuthorityDtoValidator() 
        {
            Include(new IDemandAuthorityDtoValidator());

            RuleFor(b => b.DemandAuthorityId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
