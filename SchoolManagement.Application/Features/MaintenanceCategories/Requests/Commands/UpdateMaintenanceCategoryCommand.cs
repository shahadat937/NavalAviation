using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Commands
{
    public class UpdateMaintenanceCategoryCommand : IRequest<Unit>
    {
        public MaintenanceCategoryDto MaintenanceCategoryDto { get; set; }
    }
}
