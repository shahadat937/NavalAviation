using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.StockTransferNsd
{
    public interface IStockTransferNsdDto
    {
        public int StockTransferNsdId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemStorId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ToolsLocationId { get; set; }
        public int? issuedQty { get; set; }
        public int? NsdQty { get; set; }
        public int? AvailableQty { get; set; }
        public int? TransferQty { get; set; }
        public int? DemandAuthorityId { get; set; }
        public DateTime? StockAdjustmentDate { get; set; }
        public string? Doc { get; set; }
        public int? CompleteStatus { get; set; }
        public int? Status { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
     } 
}
