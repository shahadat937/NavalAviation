using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.DTOs.StockTransferNsd.Validators
{
    public class UpdateStockTransferNsdDtoValidator : AbstractValidator<CreateStockTransferNsdDto>
    {
        public UpdateStockTransferNsdDtoValidator()
        {
            Include(new IStockTransferNsdDtoValidator());

            RuleFor(b => b.StockTransferNsdId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}

