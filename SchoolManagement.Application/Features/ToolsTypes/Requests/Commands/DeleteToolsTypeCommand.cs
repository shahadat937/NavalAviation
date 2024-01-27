using MediatR;

namespace SchoolManagement.Application.Features.ToolsTypes.Requests.Commands
{
    public class DeleteToolsTypeCommand : IRequest
    {
        public int ToolsTypeId { get; set; }
    }
} 
