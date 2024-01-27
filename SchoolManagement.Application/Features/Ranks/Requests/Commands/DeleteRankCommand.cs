using MediatR;

namespace SchoolManagement.Application.Features.Ranks.Requests.Commands
{
    public class DeleteRankCommand : IRequest
    {
        public int RankId { get; set; }
    }
}
