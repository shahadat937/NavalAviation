using MediatR;
using SchoolManagement.Application.DTOs.Rank;

namespace SchoolManagement.Application.Features.Ranks.Requests.Commands
{
    public class UpdateRankCommand : IRequest<Unit>
    {
        public RankDto RankDto { get; set; }
    }
}
