using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ToolsBoxName: BaseDomainEntity
    {
        public ToolsBoxName()
        {
            ItemStors = new HashSet<ItemStor>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
        }

        public int ToolsBoxNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
    }
}
