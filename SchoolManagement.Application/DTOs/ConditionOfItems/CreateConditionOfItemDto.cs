namespace SchoolManagement.Application.DTOs.ConditionOfItems
{
    public class CreateConditionOfItemDto : IConditionOfItemDto
    {
        public int ConditionOfItemId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
