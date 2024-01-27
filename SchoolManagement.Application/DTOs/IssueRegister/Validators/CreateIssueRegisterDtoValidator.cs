using FluentValidation;
using SchoolManagement.Application.DTOs.IssueRegister.MultipleInsertDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.IssueRegister.Validators
{
    public class CreateIssueRegisterDtoValidator : AbstractValidator<CreateIssueRegisterDto>
    {
        public CreateIssueRegisterDtoValidator()  
        {
            Include(new IIssueRegisterDtoValidator()); 
        }
    }
}
