using MediatR;
using SchoolManagement.Application.DTOs.Trade;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Trades.Requests.Queries
{
    public class GetTradeListRequest : IRequest<PagedResult<TradeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
