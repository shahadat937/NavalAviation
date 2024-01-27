using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.IssueRegister.Validators
{
    public class UpdateIssueRegisterDtoValidator : AbstractValidator<IssueRegisterDto>
    {
        public UpdateIssueRegisterDtoValidator()
        {
            Include(new IIssueRegisterDtoValidator());

            RuleFor(b => b.IssueRegisterId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

