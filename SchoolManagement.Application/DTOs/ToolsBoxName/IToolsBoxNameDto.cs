namespace SchoolManagement.Application.DTOs.ToolsBoxNames
{
    public interface IToolsBoxNameDto
    { 
        public int ToolsBoxNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
