using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
    public class GetMaintenanceScheduleListByDateRangeRequest : IRequest<List<MaintenanceScheduleListDto>>
    {
        public int MaintenancePlanningId { get; set; }  
        public int DiffBetween { get; set; }
    } 
}

