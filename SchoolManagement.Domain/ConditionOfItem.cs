using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ConditionOfItem : BaseDomainEntity
    {
        public ConditionOfItem()
        {
            Acceptances = new HashSet<Acceptance>();
            Demands = new HashSet<Demand>();
            ItemStors = new HashSet<ItemStor>();
            MeaSquadronStates = new HashSet<MeaSquadronState>();
        }

        public int ConditionOfItemId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<MeaSquadronState> MeaSquadronStates { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
    }
}
