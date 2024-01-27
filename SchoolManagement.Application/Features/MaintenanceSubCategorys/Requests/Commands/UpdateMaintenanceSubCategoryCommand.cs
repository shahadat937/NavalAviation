using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Commands
{
    public class UpdateMaintenanceSubCategoryCommand : IRequest<Unit>
    {
        public MaintenanceSubCategoryDto MaintenanceSubCategoryDto { get; set; }
    }
}
