using MediatR;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands
{
    public class DeleteStockTransferNsdCommand : IRequest
    {
        public int StockTransferNsdId { get; set; }
    }
}
