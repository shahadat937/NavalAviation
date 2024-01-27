using SchoolManagement.Application.DTOs.AcStatuss;

namespace SchoolManagement.Application.DTOs.AcStatus 
{
    public class CreateAcStatusDto : IAcStatusDto
    {
        public int AcStatusId { get; set; }
        public int AirCraftNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? StatusId { get; set; }
        public string? ExcepRelease { get; set; }
        public string? UpcomingMaint { get; set; }
        public DateTime? PlannedDate { get; set; }
        public string? RequiredDays { get; set; }
        public string? Remarks { get; set; }
        public int? CompletedStatus { get; set; }
        public int? AircraftStatusCheck { get; set; }
        public bool IsActive { get; set; }
    }
}
