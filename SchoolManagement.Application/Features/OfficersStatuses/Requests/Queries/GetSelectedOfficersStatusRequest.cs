using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.OfficersStatuses.Requests.Queries
{
    public class GetSelectedOfficersStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
