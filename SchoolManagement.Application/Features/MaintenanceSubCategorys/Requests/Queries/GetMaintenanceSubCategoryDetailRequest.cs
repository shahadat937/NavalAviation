using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries
{
    public class GetMaintenanceSubCategoryDetailRequest : IRequest<MaintenanceSubCategoryDto>
    {
        public int MaintenanceSubCategoryId { get; set; }
    }
}
