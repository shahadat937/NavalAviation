using SchoolManagement.Application.DTOs.SailorRank;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.SailorRanks.Requests.Commands
{
    public class CreateSailorRankCommand : IRequest<BaseCommandResponse>
    {
        public CreateSailorRankDto SailorRankDto { get; set; }

    }
}
