using MediatR;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Requests.Commands
{
    public class DeleteMaintenanceCategoryCommand : IRequest
    {
        public int MaintenanceCategoryId { get; set; }
    }
}
