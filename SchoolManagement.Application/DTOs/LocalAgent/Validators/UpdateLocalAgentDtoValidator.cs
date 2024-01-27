using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.LocalAgent.Validators
{
    public class UpdateLocalAgentDtoValidator : AbstractValidator<LocalAgentDto>
    {
        public UpdateLocalAgentDtoValidator()
        {
            Include(new ILocalAgentDtoValidator());

            RuleFor(b => b.LocalAgentId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

