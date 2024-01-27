using MediatR;
using SchoolManagement.Application.DTOs.MeaSquadronState;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class UpdateMeaSquadronStateCommand : IRequest<Unit>
    { 
        public MeaSquadronStateDto MeaSquadronStateDto { get; set; }
    }
}
 