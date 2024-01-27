namespace SchoolManagement.Application.DTOs.ToolsTypes
{
    public class ToolsTypeDto : IToolsTypeDto
    {
        public int ToolsTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
