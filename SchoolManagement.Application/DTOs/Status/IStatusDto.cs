namespace SchoolManagement.Application.DTOs.Status
{
    public interface IStatusDto
    {
        public int StatusId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
