using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries
{
    public class GetSelectedMaintenanceCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
