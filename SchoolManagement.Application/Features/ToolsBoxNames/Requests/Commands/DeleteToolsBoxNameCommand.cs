using MediatR;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Requests.Commands
{
    public class DeleteToolsBoxNameCommand : IRequest
    {
        public int ToolsBoxNameId { get; set; }
    }
} 
 