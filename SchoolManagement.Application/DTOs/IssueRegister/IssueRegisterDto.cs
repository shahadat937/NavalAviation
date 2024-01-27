using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.IssueRegister
{
    public class IssueRegisterDto : IIssueRegisterDto
    {
        public int IssueRegisterId { get; set; }
        public int? ItemStoreId { get; set; }
        public int? DepartmentNameId { get; set; }
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

        public string? Pno { get; set; }
        public string? Name { get; set; }
        public string? ItemName { get; set; }
        public string? PartNO { get; set; }
    }
}
