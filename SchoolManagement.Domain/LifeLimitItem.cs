using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class LifeLimitItem : BaseDomainEntity
    {
        public LifeLimitItem()
        {
            LifeLimitItemRunningHours = new HashSet<LifeLimitItemRunningHour>();
            ItemStors = new HashSet<ItemStor>();
        }

        public int LifeLimitItemId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<LifeLimitItemRunningHour> LifeLimitItemRunningHours { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
    }
}
