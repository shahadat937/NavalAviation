using MediatR;
using SchoolManagement.Application.DTOs.ToolsLocation;

namespace SchoolManagement.Application.Features.ToolsLocations.Requests.Queries
{
    public class GetToolsLocationDetailRequest : IRequest<ToolsLocationDto>
    {
        public int ToolsLocationId { get; set; }
    }
}
 