using MediatR;
using SchoolManagement.Application.DTOs.OfficersStatus;

namespace SchoolManagement.Application.Features.OfficersStatuses.Requests.Commands
{
    public class UpdateOfficersStatusCommand : IRequest<Unit>
    {
        public OfficersStatusDto OfficersStatusDto { get; set; }
    }
}
