using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NameofPublication.Validators
{
    public class CreateNameofPublicationDtoValidator : AbstractValidator<CreateNameofPublicationDto>
    {
        public CreateNameofPublicationDtoValidator()  
        {
            Include(new INameofPublicationDtoValidator()); 
        }
    }
}
