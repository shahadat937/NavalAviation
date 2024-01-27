using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries
{
    public class GetSelectedMaintenanceCategoryByDepartmentRequest : IRequest<List<SelectedModel>>
    { 
        public int DepartmentNameId { get; set; } 
    }
}
