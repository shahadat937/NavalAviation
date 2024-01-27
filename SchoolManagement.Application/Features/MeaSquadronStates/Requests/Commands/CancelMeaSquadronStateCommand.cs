using MediatR;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class CancelMeaSquadronStateCommand : IRequest 
    {
        public int MeaSquadronStateId { get; set; } 
    }
}
