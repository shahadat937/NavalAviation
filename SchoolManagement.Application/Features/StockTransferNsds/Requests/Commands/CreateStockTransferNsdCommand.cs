using MediatR;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands
{
    public class CreateStockTransferNsdCommand : IRequest<BaseCommandResponse>
    {
        public CreateStockTransferNsdDto StockTransferNsdDto { get; set; }
    }
}
