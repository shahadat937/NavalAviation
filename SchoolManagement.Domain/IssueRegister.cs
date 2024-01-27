using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class IssueRegister : BaseDomainEntity
    {
        public IssueRegister()
        {
            Surveys = new HashSet<Survey>();
        }
        public int IssueRegisterId { get; set; }
        public int? ItemStoreId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? IssueStatusId { get; set; }
        public int? TotalReceivedQty { get; set; }
        public int? IssueQty { get; set; }
        public int? ReturnQty { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? LastCalibrationDate { get; set; }
        public int? TrainingCrewId { get; set; }
        public string? IssuedTo { get; set; }
        public string? Reason { get; set; }
        public bool? IsRefundable { get; set; }
        public int? AvailableQtyBeforeIssue { get; set; }
        public int? AvailableQtyAfterIssue { get; set; }
        public string? ReceivedPerson { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ItemStor? ItemStor { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual IssueStatus? IssueStatus { get; set; }
        public virtual SparesCategory? SparesCategory { get; set; }
        public virtual TrainingCrew? TrainingCrew { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
