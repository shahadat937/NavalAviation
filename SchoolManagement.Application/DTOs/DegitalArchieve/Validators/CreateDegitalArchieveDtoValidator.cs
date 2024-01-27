using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DegitalArchieve.Validators
{
    public class CreateDegitalArchieveDtoValidator : AbstractValidator<CreateDegitalArchieveDto>
    {
        public CreateDegitalArchieveDtoValidator()  
        {
            Include(new IDegitalArchieveDtoValidator()); 
        }
    }
}
