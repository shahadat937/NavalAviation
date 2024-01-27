using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Trades.Requests.Queries
{
    public class GetSelectedTradeRequest : IRequest<List<SelectedModel>>
    {
    }
}
