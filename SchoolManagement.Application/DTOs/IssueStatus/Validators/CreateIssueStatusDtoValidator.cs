using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.IssueStatus.Validators
{
    public class CreateIssueStatusDtoValidator : AbstractValidator<CreateIssueStatusDto>
    {
        public CreateIssueStatusDtoValidator()  
        {
            Include(new IIssueStatusDtoValidator()); 
        }
    }
}
