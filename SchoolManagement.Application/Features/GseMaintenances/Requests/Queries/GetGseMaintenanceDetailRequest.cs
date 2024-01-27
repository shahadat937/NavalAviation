using MediatR;
using SchoolManagement.Application.DTOs.GseMaintenance;

namespace SchoolManagement.Application.Features.GseMaintenances.Requests.Queries
{
    public class GetGseMaintenanceDetailRequest : IRequest<GseMaintenanceDto>
    {
        public int GseMaintenanceId { get; set; }
    }
}
