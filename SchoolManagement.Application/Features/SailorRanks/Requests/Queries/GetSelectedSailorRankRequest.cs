using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SailorRanks.Requests.Queries
{
    public class GetSelectedSailorRankRequest : IRequest<List<SelectedModel>>
    {
    }
}
