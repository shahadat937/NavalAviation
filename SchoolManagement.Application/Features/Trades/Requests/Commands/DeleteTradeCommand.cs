using MediatR;

namespace SchoolManagement.Application.Features.Trades.Requests.Commands
{
    public class DeleteTradeCommand : IRequest
    {
        public int TradeId { get; set; }
    }
}
