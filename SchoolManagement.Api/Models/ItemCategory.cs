using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Acceptances = new HashSet<Acceptance>();
            Demands = new HashSet<Demand>();
            EquipmentIssues = new HashSet<EquipmentIssue>();
            ItemDetails = new HashSet<ItemDetail>();
            ItemStors = new HashSet<ItemStor>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
            Procurements = new HashSet<Procurement>();
            Surveys = new HashSet<Survey>();
            ToolsIssues = new HashSet<ToolsIssue>();
        }

        public int ItemCategoryId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<EquipmentIssue> EquipmentIssues { get; set; }
        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<ToolsIssue> ToolsIssues { get; set; }
    }
}
