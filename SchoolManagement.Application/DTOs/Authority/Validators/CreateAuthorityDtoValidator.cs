using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Authority.Validators
{
    public class CreateAuthorityDtoValidator : AbstractValidator<CreateAuthorityDto>
    {
        public CreateAuthorityDtoValidator()  
        {
            Include(new IAuthorityDtoValidator()); 
        }
    }
}
