using MediatR;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Ranks.Requests.Commands
{
    public class CreateRankCommand : IRequest<BaseCommandResponse>
    {
        public CreateRankDto RankDto { get; set; }
    }
}
