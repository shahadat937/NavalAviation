using MediatR;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Commands
{
    public class DeleteMaintenanceSubCategoryCommand : IRequest
    {
        public int MaintenanceSubCategoryId { get; set; }
    }
}
