using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class SparesCategory : BaseDomainEntity
    {
        public SparesCategory()
        {
            Acceptances = new HashSet<Acceptance>();
            Demands = new HashSet<Demand>();
            ItemDetails = new HashSet<ItemDetail>();
            IssueRegisters = new HashSet<IssueRegister>();
            ItemStors = new HashSet<ItemStor>();
            Procurements = new HashSet<Procurement>();
            EquipmentNames = new HashSet<EquipmentName>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
            RequiredSparesForMaintenances = new HashSet<RequiredSparesForMaintenance>();
        }

        public int SparesCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
        public virtual ICollection<IssueRegister> IssueRegisters { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<EquipmentName> EquipmentNames { get; set; }
    }
}
