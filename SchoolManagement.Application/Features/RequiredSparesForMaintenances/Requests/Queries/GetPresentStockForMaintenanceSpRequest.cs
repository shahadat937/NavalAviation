using MediatR;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries
{
    public class GetPresentStockForMaintenanceSpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
        public int SparesCategoryId { get; set; }
        public int MaintenanceTypeId { get; set; }
        public int MaintenanceCategoryId { get; set; }
        public int MaintenanceSubCategoryId { get; set; }
    }
}
