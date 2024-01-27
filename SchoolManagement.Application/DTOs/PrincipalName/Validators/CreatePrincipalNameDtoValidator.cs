using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.PrincipalName.Validators
{
    public class CreatePrincipalNameDtoValidator : AbstractValidator<CreatePrincipalNameDto>
    {
        public CreatePrincipalNameDtoValidator()  
        {
            Include(new IPrincipalNameDtoValidator()); 
        }
    }
}
