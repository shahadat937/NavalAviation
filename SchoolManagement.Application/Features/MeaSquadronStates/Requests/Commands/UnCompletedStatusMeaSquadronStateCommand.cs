using MediatR;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class UnCompletedStatusMeaSquadronStateCommand : IRequest 
    {
        public int MeaSquadronStateId { get; set; } 
    }
}
