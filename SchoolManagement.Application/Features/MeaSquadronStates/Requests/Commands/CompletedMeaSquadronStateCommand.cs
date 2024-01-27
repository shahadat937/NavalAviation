using MediatR;
using SchoolManagement.Application.DTOs.MeaSquadronState;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class CompletedMeaSquadronStateCommand : IRequest<Unit>
    {
        public CompletedMeaSquadronStateDto CompletedMeaSquadronStateDto { get; set; }
    }
} 
