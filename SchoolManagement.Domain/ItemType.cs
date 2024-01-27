using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ItemType : BaseDomainEntity
    {
        public ItemType()
        {
            Demands = new HashSet<Demand>();
            ItemDetails = new HashSet<ItemDetail>();
        }

        public int ItemTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
    }
}
