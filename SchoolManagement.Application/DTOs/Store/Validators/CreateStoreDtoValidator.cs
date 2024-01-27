using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Store.Validators
{
    public class CreateStoreDtoValidator : AbstractValidator<CreateStoreDto>
    {
        public CreateStoreDtoValidator()  
        {
            Include(new IStoreDtoValidator()); 
        }
    }
}
