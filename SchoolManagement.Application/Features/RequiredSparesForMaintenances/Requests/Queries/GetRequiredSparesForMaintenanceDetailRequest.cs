using MediatR;
using SchoolManagement.Application.DTOs.RequiredSparesForMaintenance;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries
{
    public class GetRequiredSparesForMaintenanceDetailRequest : IRequest<RequiredSparesForMaintenanceDto>
    {
        public int RequiredSparesForMaintenanceId { get; set; }
    }
}
