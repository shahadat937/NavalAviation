using MediatR;
using SchoolManagement.Application.DTOs.OfficersStatus;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.OfficersStatuses.Requests.Commands
{
    public class CreateOfficersStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateOfficersStatusDto OfficersStatusDto { get; set; }
    }
}
