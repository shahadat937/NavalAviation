using MediatR;
using SchoolManagement.Application.DTOs.MeaSquadronState;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands
{
    public class CreateMeaSquadronStateCommand : IRequest<BaseCommandResponse>
    {
        public CreateMeaSquadronStateDto MeaSquadronStateDto { get; set; }
    }
}
