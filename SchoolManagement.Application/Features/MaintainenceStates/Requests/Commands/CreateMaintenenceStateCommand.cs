using MediatR;
using SchoolManagement.Application.DTOs.MaintenenceState;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands
{
    public class CreateMaintenenceStateCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaintenenceStateDto MaintenenceStateDto { get; set; }
    }
}
