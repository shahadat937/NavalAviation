using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class MaintenancePlanning : BaseDomainEntity
    {
        public MaintenancePlanning()
        {
            MaintenanceSchedules = new HashSet<MaintenanceSchedule>();
        }
        public int MaintenancePlanningId { get; set; }
        public int? AirCraftNameId { get; set; }
        public string? SlNo { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? MaintenanceSubCategoryId { get; set; }
        public int? MaintenancePlanningStatusId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ReportCalculationDay { get; set; }
        public DateTime? LastInspDate { get; set; }
        public DateTime? NestInspDate { get; set; }
        public string? LastInspectionDay { get; set; }
        public string? NextInspectionDay { get; set; }
        public string? LastInspectionFH { get; set; }
        public string? NextInspectionFH { get; set; }
        public string? LastInspectionOH { get; set; }
        public string? NextInspectionOH { get; set; }
        public bool? ExtensionGiven { get; set; }
        public string? ExtensionDay { get; set; }
        public string? RequiredDay { get; set; }
        public DateTime? CommencingDate { get; set; }
        public DateTime? PlannedCompletionDate { get; set; }
        public string? Remarks { get; set; }
        public string? MaintenanceDocument { get; set; }
        public string? ExtensionDocument { get; set; }
        public string? OthersDocument { get; set; }
        public string? JobListDocument { get; set; }
        public string? RequiredSpearsDoc { get; set; }
        public string? RequiredToolsDoc { get; set; }
        public string? RequiredConsumablesDoc { get; set; }
        public string? ToleranceDocument { get; set; }
        public int? Status { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public int? MenuPosition { get; set; }
        public int? CompletStatus { get; set; }
        public bool IsActive { get; set; }

        public virtual MaintenancePlanningStatus? MaintenancePlanningStatus { get; set; }
        public virtual AirCraftName? AirCraftName { get; set; }
        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual MaintenanceCategory? MaintenanceCategory { get; set; }
        public virtual MaintenanceSubCategory? MaintenanceSubCategory { get; set; }
        public virtual MaintenanceType? MaintenanceType { get; set; }

        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
    }
}
