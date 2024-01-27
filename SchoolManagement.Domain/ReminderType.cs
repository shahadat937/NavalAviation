using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ReminderType : BaseDomainEntity
    {
        public ReminderType()
        {
            ItemReminders = new HashSet<ItemReminder>();
        }

        public int ReminderTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ItemReminder> ItemReminders { get; set; }
    }
}
