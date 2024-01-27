using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.LocalAgent.Validators
{
    public class CreateLocalAgentDtoValidator : AbstractValidator<CreateLocalAgentDto>
    {
        public CreateLocalAgentDtoValidator()  
        {
            Include(new ILocalAgentDtoValidator()); 
        }
    }
}
