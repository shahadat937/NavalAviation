using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetSelectedMaintenanceSubCategoryByDepartmentIdRequest : IRequest<List<SelectedModel>>
    {
        public int DepartmentNameId { get; set; }
     }
}
