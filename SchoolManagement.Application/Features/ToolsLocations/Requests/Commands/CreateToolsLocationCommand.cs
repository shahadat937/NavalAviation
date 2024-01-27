using MediatR;
using SchoolManagement.Application.DTOs.ToolsLocation;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ToolsLocations.Requests.Commands
{
    public class CreateToolsLocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateToolsLocationDto ToolsLocationDto { get; set; }
    }
}
 