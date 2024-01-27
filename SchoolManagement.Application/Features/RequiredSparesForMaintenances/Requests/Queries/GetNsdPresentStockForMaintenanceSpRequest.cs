using MediatR;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries
{
    public class GetNsdPresentStockForMaintenanceSpRequest : IRequest<object>
    {
        public int ItemDetailId { get; set; }
        public int ToolsLocationId { get; set; }
    }
}
