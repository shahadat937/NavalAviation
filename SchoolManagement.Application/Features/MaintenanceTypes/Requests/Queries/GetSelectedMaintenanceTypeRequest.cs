using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries
{
    public class GetSelectedMaintenanceTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
