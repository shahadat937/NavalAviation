using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.MaintenancePlanning;

namespace SchoolManagement.Application.DTOs.ReadingMaterial
{
    public class CreatePlanningDto
    {
        public IFormFile JobList { get; set; }
        public CreateMaintenancePlanningDto MaintenancePlanningForm { get; set; }
    }
}
