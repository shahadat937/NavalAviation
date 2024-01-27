using MediatR;
using SchoolManagement.Application.DTOs.AcStatus;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Commands
{
    public class UpdateAcStatusCommand : IRequest<Unit>
    { 
        public AcStatusDto AcStatusDto { get; set; }
    }
}
