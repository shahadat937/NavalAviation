namespace SchoolManagement.Application.DTOs.IssueRegister.MultipleInsertDto
{
    public class CreateIssueRegisterDto : IIssueRegisterDto
    {
        public int? IssueRegisterId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? IssueStatusId { get; set; }
        public int? TotalReceivedQty { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? LastCalibrationDate { get; set; }
        public int? TrainingCrewId { get; set; }
        public int? ReturnQty { get; set; }
        public string? IssuedTo { get; set; }
        public string? Reason { get; set; } 
        public string? Remarks { get; set; }
        public int? AvailableQtyBeforeIssue { get; set; }
        public int? AvailableQtyAfterIssue { get; set; }
        public string? ReceivedPerson { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }
        public List<ItemStoreList>? ItemStoreList { get; set; }       
    }
}
