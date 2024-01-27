using MediatR;
using SchoolManagement.Application.DTOs.Trade;

namespace SchoolManagement.Application.Features.Trades.Requests.Queries
{
    public class GetTradeDetailRequest : IRequest<TradeDto>
    {
        public int TradeId { get; set; }
    }
}
