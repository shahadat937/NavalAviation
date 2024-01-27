namespace SchoolManagement.Application.DTOs.EndLifeTypes
{
    public class EndLifeTypeDto : IEndLifeTypeDto
    {
        public int EndLifeTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
