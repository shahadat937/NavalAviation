using MediatR;
using SchoolManagement.Application.DTOs.MaintenanceSchedule;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries
{
    public class GetMaintenanceScheduleListByDepartmentNameIdRequest : IRequest<List<MaintenanceScheduleDto>>
    {
        public int AirCraftNameId { get; set; }  
        public int DepartmentNameId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
  } 
}

