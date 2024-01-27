using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetSelectedMaintenanceSubCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
