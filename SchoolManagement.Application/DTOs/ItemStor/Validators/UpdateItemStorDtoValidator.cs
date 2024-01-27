using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ItemStor.Validators
{
    public class UpdateItemStorDtoValidator : AbstractValidator<CreateItemStorDto>
    {
        public UpdateItemStorDtoValidator()
        {
            Include(new IItemStorDtoValidator());

            RuleFor(b => b.ItemStorId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

