using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.IssueStatus.Validators
{
    public class UpdateIssueStatusDtoValidator : AbstractValidator<IssueStatusDto>
    {
        public UpdateIssueStatusDtoValidator()
        {
            Include(new IIssueStatusDtoValidator());

            RuleFor(b => b.IssueStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

