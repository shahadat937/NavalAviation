using MediatR;
using SchoolManagement.Application.DTOs.StockTransferNsd;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries
{
    public class GetStockTransferNsdDetailRequest : IRequest<StockTransferNsdDto>
    {
        public int StockTransferNsdId { get; set; }
    }
}
