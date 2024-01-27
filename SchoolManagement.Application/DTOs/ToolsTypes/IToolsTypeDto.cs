namespace SchoolManagement.Application.DTOs.ToolsTypes
{
    public interface IToolsTypeDto
    {
        public int ToolsTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
