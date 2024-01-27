using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ConditionOfItem
    {
        public ConditionOfItem()
        {
            Acceptances = new HashSet<Acceptance>();
            Demands = new HashSet<Demand>();
            ItemStors = new HashSet<ItemStor>();
            MeaSquadronStates = new HashSet<MeaSquadronState>();
        }

        public int ConditionOfItemId { get; set; }
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
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<MeaSquadronState> MeaSquadronStates { get; set; }
    }
}
