using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Commands
{
    public class CreateMaintenanceSubCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaintenanceSubCategoryDto MaintenanceSubCategoryDto { get; set; }
    }
}
