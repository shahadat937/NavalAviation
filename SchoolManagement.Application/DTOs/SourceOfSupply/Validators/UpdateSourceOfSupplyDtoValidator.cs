using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.SourceOfSupply.Validators
{
    public class UpdateSourceOfSupplyDtoValidator : AbstractValidator<SourceOfSupplyDto>
    {
        public UpdateSourceOfSupplyDtoValidator()
        {
            Include(new ISourceOfSupplyDtoValidator());

            RuleFor(b => b.SourceOfSupplyId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

