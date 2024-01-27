using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ToolsLocations.Requests.Queries
{
    public class GetSelectedToolsLocationRequest : IRequest<List<SelectedModel>>
    {
    }
}
 