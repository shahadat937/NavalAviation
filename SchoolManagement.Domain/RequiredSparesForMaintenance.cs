using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class RequiredSparesForMaintenance : BaseDomainEntity
    {
        public RequiredSparesForMaintenance()
        {
            
        }

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
        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual AirCraftName? AirCraftName { get; set; }
        public virtual SparesCategory? SparesCategory { get; set; }
        public virtual MaintenanceType? MaintenanceType { get; set; }
        public virtual MaintenanceCategory? MaintenanceCategory { get; set; }
        public virtual MaintenanceSubCategory? MaintenanceSubCategory { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }


    }
}
