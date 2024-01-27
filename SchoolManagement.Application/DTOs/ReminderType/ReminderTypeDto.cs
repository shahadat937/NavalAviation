namespace SchoolManagement.Application.DTOs.ReminderType
{
    public class ReminderTypeDto : IReminderTypeDto
    {
        public int ReminderTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
