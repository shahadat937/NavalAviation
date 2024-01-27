using MediatR;
using SchoolManagement.Application.DTOs.Trade;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Trades.Requests.Commands
{
    public class CreateTradeCommand : IRequest<BaseCommandResponse>
    {
        public CreateTradeDto TradeDto { get; set; }
    }
}
