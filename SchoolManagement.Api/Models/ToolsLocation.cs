using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ToolsLocation
    {
        public ToolsLocation()
        {
            ItemStors = new HashSet<ItemStor>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
            StockTransferNsds = new HashSet<StockTransferNsd>();
        }

        public int ToolsLocationId { get; set; }
        public string ToolsLocationName { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<StockTransferNsd> StockTransferNsds { get; set; }
    }
}
