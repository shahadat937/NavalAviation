using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.ProcurementStatus.Validators
{
    public class UpdateProcurementStatusDtoValidator : AbstractValidator<ProcurementStatusDto>
    {
        public UpdateProcurementStatusDtoValidator()
        {
            Include(new IProcurementStatusDtoValidator());

            RuleFor(b => b.ProcurementStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

