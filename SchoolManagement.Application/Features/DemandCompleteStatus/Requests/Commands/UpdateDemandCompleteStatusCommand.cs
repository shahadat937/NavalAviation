using MediatR;
using SchoolManagement.Application.DTOs.DemandCompleteStatuses;

namespace SchoolManagement.Application.Features.DemandCompleteStatuses.Requests.Commands
{
    public class UpdateDemandCompleteStatusCommand : IRequest<Unit>
    { 
        public DemandCompleteStatusDto DemandCompleteStatusDto { get; set; }
    }
}
