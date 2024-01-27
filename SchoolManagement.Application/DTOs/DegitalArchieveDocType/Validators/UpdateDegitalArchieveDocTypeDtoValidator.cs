using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.DegitalArchieveDocType.Validators
{
    public class UpdateDegitalArchieveDocTypeDtoValidator : AbstractValidator<DegitalArchieveDocTypeDto>
    {
        public UpdateDegitalArchieveDocTypeDtoValidator()
        {
            Include(new IDegitalArchieveDocTypeDtoValidator());

            RuleFor(b => b.DegitalArchieveDocTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

