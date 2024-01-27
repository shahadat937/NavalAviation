using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SourceOfSupply.Validators
{
    public class CreateSourceOfSupplyDtoValidator : AbstractValidator<CreateSourceOfSupplyDto>
    {
        public CreateSourceOfSupplyDtoValidator()  
        {
            Include(new ISourceOfSupplyDtoValidator()); 
        }
    }
}
