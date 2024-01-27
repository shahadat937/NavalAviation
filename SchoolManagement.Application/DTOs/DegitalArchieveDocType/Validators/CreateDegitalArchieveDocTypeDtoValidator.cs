using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DegitalArchieveDocType.Validators
{
    public class CreateDegitalArchieveDocTypeDtoValidator : AbstractValidator<CreateDegitalArchieveDocTypeDto>
    {
        public CreateDegitalArchieveDocTypeDtoValidator()  
        {
            Include(new IDegitalArchieveDocTypeDtoValidator()); 
        }
    }
}
