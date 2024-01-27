using MediatR;
using SchoolManagement.Application.DTOs.Rank;

namespace SchoolManagement.Application.Features.Ranks.Requests.Queries
{
    public class GetRankDetailRequest : IRequest<RankDto>
    {
        public int RankId { get; set; }
    }
}
