using Microsoft.AspNetCore.Http;


namespace SchoolManagement.Application.DTOs.MaintenanceSchedule
{
    public class CreateMaintenanceScheduleDto : IMaintenanceScheduleDto
    {
        public int MaintenanceScheduleId { get; set; }
        public int? MaintenancePlanningId { get; set; }
        public int? AirCraftNameId { get; set; }
        public string? SlNo { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? MaintenanceSubCategoryId { get; set; }
        public int? MaintenancePlanningStatusId { get; set; }
        public int? DepartmentNameId { get; set; }
        public DateTime? StartInspDate { get; set; }
        public DateTime? EndInspDate { get; set; }
        public string? AllowedExtension { get; set; }
        public string? ExtensionGiven { get; set; }
        public string? ExtensionDay { get; set; }
        public string? RequiredDay { get; set; }
        public string? Remarks { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string? MaintenanceDocument { get; set; }
        public string? ExtensionDocument { get; set; }
        public string? OthersDocument { get; set; }
        public string? JobListDocument { get; set; }
        public string? RequiredSpearsDoc { get; set; }
        public string? RequiredToolsDoc { get; set; }
        public string? RequiredConsumablesDoc { get; set; }
        public string? ToleranceDocument { get; set; }
        public string? ProgressBar { get; set; }
        public int? Status { get; set; }
        public int? InspCompleteStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public IFormFile? Doc { get; set; }
    }
}
