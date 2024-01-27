using FluentValidation;

namespace SchoolManagement.Application.DTOs.Demands.Validators
{
    public class UpdateDemandDtoValidator : AbstractValidator<CreateDemandDto>
    {
        public UpdateDemandDtoValidator() 
        {
            Include(new IDemandDtoValidator());

            RuleFor(b => b.DemandId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
