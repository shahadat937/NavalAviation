using SchoolManagement.Application.DTOs.SailorRank;
using MediatR;

namespace SchoolManagement.Application.Features.SailorRanks.Requests.Queries
{
    public class GetSailorRankDetailRequest : IRequest<SailorRankDto>
    {
        public int SailorRankId { get; set; }
    }
}
