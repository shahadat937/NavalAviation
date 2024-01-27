using FluentValidation;

namespace SchoolManagement.Application.DTOs.ToolsTypes.Validators
{
    public class CreateToolsTypeDtoValidator : AbstractValidator<CreateToolsTypeDto>
    {
        public CreateToolsTypeDtoValidator()
        {
            Include(new IToolsTypeDtoValidator());
        }
    }
}
 