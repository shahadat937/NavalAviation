using FluentValidation;

namespace SchoolManagement.Application.DTOs.DemandCompleteStatuses.Validators
{
    public class CreateDemandCompleteStatusDtoValidator : AbstractValidator<CreateDemandCompleteStatusDto>
    {
        public CreateDemandCompleteStatusDtoValidator()
        {
            Include(new IDemandCompleteStatusDtoValidator());
        }
    }
}
 