using MediatR;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class AcceptMeaSquadronStateCommand : IRequest 
    {
        public int MeaSquadronStateId { get; set; } 
    }
}
