using MediatR;
using SchoolManagement.Application.DTOs.Status;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Statuses.Requests.Commands
{
    public class CreateStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateStatusDto StatusDto { get; set; }
    }
}
