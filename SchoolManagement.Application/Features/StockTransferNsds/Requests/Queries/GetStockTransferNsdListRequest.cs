using MediatR;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries
{
    public class GetStockTransferNsdListRequest : IRequest<PagedResult<StockTransferNsdDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
