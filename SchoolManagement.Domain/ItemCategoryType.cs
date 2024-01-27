using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ItemCategoryType : BaseDomainEntity
    {
        public ItemCategoryType()
        {
            ItemDetails = new HashSet<ItemDetail>();
        }

        public int ItemCategoryTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
    }
}
