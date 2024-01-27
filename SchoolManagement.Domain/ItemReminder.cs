using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ItemReminder : BaseDomainEntity
    {
        public int ItemReminderId { get; set; }
        public int? ProcurementId { get; set; }
        public int? ReminderTypeId { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string? ReminderStep { get; set; }
        public string? ReminderDocument { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Procurement? Procurement { get; set; }
        public virtual ReminderType? ReminderType { get; set; }
    }
}
