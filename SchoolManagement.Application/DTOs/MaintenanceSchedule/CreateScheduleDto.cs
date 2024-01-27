using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.MaintenanceSchedule
{
    public class CreateScheduleDto
    {

        public IFormFile Doc { get; set; }
        public CreateMaintenanceScheduleDto MaintenanceScheduleForm { get; set; }
}
}
