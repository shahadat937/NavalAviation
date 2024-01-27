using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ItemStor.Validators
{
    public class CreateItemStorDtoValidator : AbstractValidator<CreateItemStorDto>
    {
        public CreateItemStorDtoValidator()  
        {
            Include(new IItemStorDtoValidator()); 
        }
    }
}
