using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ItemDetail.Validators
{
    public class UpdateItemDetailDtoValidator : AbstractValidator<ItemDetailDto>
    {
        public UpdateItemDetailDtoValidator()
        {
            Include(new IItemDetailDtoValidator());

            //RuleFor(b => b.ItemDetailId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

