using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries
{
    public class GetSelectedRequiredSparesForMaintenanceRequest : IRequest<List<SelectedModel>>
    {
    }
}
