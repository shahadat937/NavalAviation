using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries
{
    public class GetMaintenanceCategoryDetailRequest : IRequest<MaintenanceCategoryDto>
    {
        public int MaintenanceCategoryId { get; set; }
    }
}
