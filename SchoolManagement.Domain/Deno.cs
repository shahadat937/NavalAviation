using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Deno : BaseDomainEntity
    {
        public Deno()
        {
            Demands = new HashSet<Demand>();
            ItemStors = new HashSet<ItemStor>();
            SurveyItems = new HashSet<SurveyItem>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
        }

        public int DenoId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<SurveyItem> SurveyItems { get; set; }
        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
    }
}
