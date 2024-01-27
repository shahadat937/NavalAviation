namespace SchoolManagement.Application.DTOs.LifeLimitItem
{
    public class CreateLifeLimitItemDto : ILifeLimitItemDto
    {
        public int LifeLimitItemId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
