using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ItemReminder
    {
        public int ItemReminderId { get; set; }
        public int? ProcurementId { get; set; }
        public int? ReminderTypeId { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string ReminderStep { get; set; }
        public string ReminderDocument { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Procurement Procurement { get; set; }
        public virtual ReminderType ReminderType { get; set; }
    }
}
