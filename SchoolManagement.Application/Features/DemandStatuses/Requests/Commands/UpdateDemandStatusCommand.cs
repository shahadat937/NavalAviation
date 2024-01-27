using MediatR;
using SchoolManagement.Application.DTOs.DemandStatus;

namespace SchoolManagement.Application.Features.DemandStatuses.Requests.Commands
{
    public class UpdateDemandStatusCommand : IRequest<Unit>
    {
        public DemandStatusDto DemandStatusDto { get; set; }
    }
}
