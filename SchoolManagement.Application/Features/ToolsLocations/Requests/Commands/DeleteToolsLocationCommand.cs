using MediatR;

namespace SchoolManagement.Application.Features.ToolsLocations.Requests.Commands
{
    public class DeleteToolsLocationCommand : IRequest
    {
        public int ToolsLocationId { get; set; }
    }
}
 