using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ItemDetail.Validators
{
    public class CreateItemDetailDtoValidator : AbstractValidator<CreateItemDetailDto>
    {
        public CreateItemDetailDtoValidator()  
        {
            Include(new IItemDetailDtoValidator()); 
        }
    }
}
