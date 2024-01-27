using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ToolsLocation.Validators
{
    public class CreateToolsLocationDtoValidator : AbstractValidator<CreateToolsLocationDto>
    {
        public CreateToolsLocationDtoValidator()  
        {
            Include(new IToolsLocationDtoValidator()); 
        }
    }
}
