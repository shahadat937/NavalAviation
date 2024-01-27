using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Ranks.Requests.Queries
{
    public class GetSelectedRankRequest : IRequest<List<SelectedModel>>
    {
    }
}
