using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Shop : BaseDomainEntity
    {
        public Shop()
        {
            TestEquipmentDetails = new HashSet<TestEquipmentDetail>();
        }
        public int ShopId { get; set; }
        public string? Name { get; set; } 
        public int? MenuPosition { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<TestEquipmentDetail> TestEquipmentDetails { get; set; }
    }
}
