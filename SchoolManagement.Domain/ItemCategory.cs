using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ItemCategory : BaseDomainEntity
    {
        public ItemCategory()
        {
            EquipmentIssues = new HashSet<EquipmentIssue>();
            ToolsIssues = new HashSet<ToolsIssue>();
            ItemStors = new HashSet<ItemStor>();
            ItemDetails = new HashSet<ItemDetail>();
            Demands = new HashSet<Demand>();
            Procurements = new HashSet<Procurement>();
            Acceptances = new HashSet<Acceptance>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
            Surveys = new HashSet<Survey>();
        }

        public int ItemCategoryId { get; set; }
        public int? SparesCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<EquipmentIssue> EquipmentIssues { get; set; }
        public virtual ICollection<ToolsIssue> ToolsIssues { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<Acceptance> Acceptances { get; set; }
    }
}
