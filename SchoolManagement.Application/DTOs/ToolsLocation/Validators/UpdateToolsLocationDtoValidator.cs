using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ToolsLocation.Validators
{
    public class UpdateToolsLocationDtoValidator : AbstractValidator<ToolsLocationDto>
    {
        public UpdateToolsLocationDtoValidator()
        {
            Include(new IToolsLocationDtoValidator());

            RuleFor(b => b.ToolsLocationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

