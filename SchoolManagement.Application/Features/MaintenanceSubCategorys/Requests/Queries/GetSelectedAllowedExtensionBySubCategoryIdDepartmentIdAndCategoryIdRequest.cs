using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetSelectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryIdRequest : IRequest<object>
    {
        public int DepartmentNameId { get; set; }
        public int MaintenanceCategoryId { get; set; }
        public int MaintenanceSubCategoryId { get; set; }
    }
}

