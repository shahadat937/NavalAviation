using MediatR;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands
{
    public class ApprovedStockTransferNsdCommand : IRequest 
    {
        public int StockTransferNsdId { get; set; } 
    }
}
