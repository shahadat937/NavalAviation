using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenancePlanning
{
    public class MaintenancePlanningDto : IMaintenancePlanningDto
    {
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

        public string? DepartmentName { get; set; }
        public string? AirCraftName { get; set; }
        public string? CategoryType { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? MPStatus { get; set; }
    }
}
