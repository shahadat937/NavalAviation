using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Commands
{
    public class CreateMaintenanceCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateMaintenanceCategoryDto MaintenanceCategoryDto { get; set; }
    }
}
