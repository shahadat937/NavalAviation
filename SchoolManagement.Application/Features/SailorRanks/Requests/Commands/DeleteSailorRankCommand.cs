using MediatR;

namespace SchoolManagement.Application.Features.SailorRanks.Requests.Commands
{
    public class DeleteSailorRankCommand : IRequest
    {
        public int SailorRankId { get; set; }
    }
}
