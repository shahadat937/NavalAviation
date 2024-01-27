using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.IssueRegister
{
    public interface IIssueRegisterDto
    {
       // public int IssueRegisterId { get; set; }
       // public int? ItemStoreId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? IssueStatusId { get; set; }
        public int? TotalReceivedQty { get; set; }
     //   public string? IssueQty { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? LastCalibrationDate { get; set; }
        public string? IssuedTo { get; set; }
        public string? Reason { get; set; }
      //  public bool? IsRefundable { get; set; }
        public int? AvailableQtyBeforeIssue { get; set; }
        public int? AvailableQtyAfterIssue { get; set; }
        public string? ReceivedPerson { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }
    } 
}
