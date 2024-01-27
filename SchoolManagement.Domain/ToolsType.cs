using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ToolsType : BaseDomainEntity
    {
        public ToolsType() 
        {
            ItemStors = new HashSet<ItemStor>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
        }
        public int ToolsTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
    }
}
