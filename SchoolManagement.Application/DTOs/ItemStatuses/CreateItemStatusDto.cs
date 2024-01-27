namespace SchoolManagement.Application.DTOs.ItemStatuses
{
    public class CreateItemStatusDto : IItemStatusDto
    {
        public int ItemStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
