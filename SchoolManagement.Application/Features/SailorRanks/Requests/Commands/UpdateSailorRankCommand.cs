using SchoolManagement.Application.DTOs.SailorRank;
using MediatR;

namespace SchoolManagement.Application.Features.SailorRanks.Requests.Commands
{
    public class UpdateSailorRankCommand : IRequest<Unit>
    {
        public SailorRankDto SailorRankDto { get; set; }

    }
}
