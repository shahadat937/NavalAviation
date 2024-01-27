using MediatR;
using SchoolManagement.Application.DTOs.ToolsBoxNames;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Requests.Commands
{
    public class UpdateToolsBoxNameCommand : IRequest<Unit>
    { 
        public ToolsBoxNameDto ToolsBoxNameDto { get; set; }
    }
}
  