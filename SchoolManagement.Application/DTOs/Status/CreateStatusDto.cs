using SchoolManagement.Application.DTOs.Status;

namespace SchoolManagement.Application.DTOs.Status 
{
    public class CreateStatusDto : IStatusDto
    {
        public int StatusId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
