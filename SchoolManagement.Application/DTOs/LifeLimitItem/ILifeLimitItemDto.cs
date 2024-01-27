namespace SchoolManagement.Application.DTOs.LifeLimitItem
{
    public interface ILifeLimitItemDto
    {
        public int LifeLimitItemId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    } 
}
