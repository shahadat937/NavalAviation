using MediatR;
using SchoolManagement.Application.DTOs.Trade;

namespace SchoolManagement.Application.Features.Trades.Requests.Commands
{
    public class UpdateTradeCommand : IRequest<Unit>
    {
        public TradeDto TradeDto { get; set; }
    }
}
