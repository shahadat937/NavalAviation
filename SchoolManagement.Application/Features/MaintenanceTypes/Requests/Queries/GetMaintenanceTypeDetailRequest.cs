using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceType;

namespace SchoolManagement.Application.Features.MaintenanceTypes.Requests.Queries
{
    public class GetMaintenanceTypeDetailRequest : IRequest<MaintenanceTypeDto>
    {
        public int MaintenanceTypeId { get; set; }
    }
}
