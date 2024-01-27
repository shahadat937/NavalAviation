using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.Store.Validators
{
    public class UpdateStoreDtoValidator : AbstractValidator<StoreDto>
    {
        public UpdateStoreDtoValidator()
        {
            Include(new IStoreDtoValidator());

            RuleFor(b => b.StoreId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

