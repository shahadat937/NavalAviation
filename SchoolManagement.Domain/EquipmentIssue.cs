using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class EquipmentIssue : BaseDomainEntity
    {
        public int EquipmentIssueId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemStoreId { get; set; }
        public string? PartNo { get; set; }
        public int? ItemCategoryId { get; set; }
        public string? IssueQuantity { get; set; }
        public string? LastStockQuantityBeforeIssue { get; set; }
        public string? TotalReceivedQuantity { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? IssuedTo { get; set; }
        public string? Reason { get; set; }
        public string? Remarks { get; set; }
        public bool? IsReturnableStatus { get; set; }
        public string? ReturnableQty { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ItemCategory? ItemCategory { get; set; }
        public virtual ItemStor? ItemStore { get; set; }
    }
}
