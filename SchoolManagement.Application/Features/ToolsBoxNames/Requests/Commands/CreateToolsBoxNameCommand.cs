using MediatR;
using SchoolManagement.Application.DTOs.ToolsBoxNames;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Requests.Commands
{
    public class CreateToolsBoxNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateToolsBoxNameDto ToolsBoxNameDto { get; set; }
    }
}
 