using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RequiredSparesForMaintenance
{
    public class CreateRequiredSparesForMaintenanceDto : IRequiredSparesForMaintenanceDto
    {
        public int RequiredSparesForMaintenanceId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        public int? MaintenanceCategoryId { get; set; }
        public int? MaintenanceSubCategoryId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
     }
}
