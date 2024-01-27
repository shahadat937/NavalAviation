using MediatR;
using SchoolManagement.Application.DTOs.Status;

namespace SchoolManagement.Application.Features.Statuses.Requests.Commands
{
    public class UpdateStatusCommand : IRequest<Unit>
    { 
        public StatusDto StatusDto { get; set; }
    }
}
