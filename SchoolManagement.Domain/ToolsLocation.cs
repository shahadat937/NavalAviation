using SchoolManagement.Domain;
using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ToolsLocation: BaseDomainEntity
    {
        public ToolsLocation()
        {
            ItemStors = new HashSet<ItemStor>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
            StockTransferNsds = new HashSet<StockTransferNsd>();
         }
        public int ToolsLocationId { get; set; }
        public string? ToolsLocationName { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<StockTransferNsd> StockTransferNsds { get; set; }
    }
}
