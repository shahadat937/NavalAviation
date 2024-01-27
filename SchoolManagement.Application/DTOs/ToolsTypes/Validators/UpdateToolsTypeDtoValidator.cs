using FluentValidation;

namespace SchoolManagement.Application.DTOs.ToolsTypes.Validators
{
    public class UpdateToolsTypeDtoValidator : AbstractValidator<ToolsTypeDto>
    {
        public UpdateToolsTypeDtoValidator() 
        {
            Include(new IToolsTypeDtoValidator());

            RuleFor(b => b.ToolsTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
