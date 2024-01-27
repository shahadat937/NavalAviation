using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class StockTransferNsd
    {
        public int StockTransferNsdId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemStorId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ToolsLocationId { get; set; }
        public int? IssuedQty { get; set; }
        public int? NsdQty { get; set; }
        public int? AvailableQty { get; set; }
        public int? TransferQty { get; set; }
        public int? DemandAuthorityId { get; set; }
        public DateTime? StockAdjustmentDate { get; set; }
        public string Doc { get; set; }
        public int? CompleteStatus { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public int? Status { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual DemandAuthority DemandAuthority { get; set; }
        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ItemDetail ItemDetail { get; set; }
        public virtual ItemStor ItemStor { get; set; }
        public virtual ToolsLocation ToolsLocation { get; set; }
    }
}
