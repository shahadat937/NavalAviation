using MediatR;
using SchoolManagement.Application.DTOs.MeaSquadronState;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Queries
{
    public class GetMeaSquadronStateDetailRequest : IRequest<MeaSquadronStateDto>
    {
        public int MeaSquadronStateId { get; set; }
    }
}
