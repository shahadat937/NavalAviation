using MediatR;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands
{
    public class UpdateStockTransferNsdCommand : IRequest<Unit>
    {
        public CreateStockTransferNsdDto UpdateStockTransferNsdDto { get; set; }
    }
}
