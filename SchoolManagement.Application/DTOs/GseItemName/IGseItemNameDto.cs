namespace SchoolManagement.Application.DTOs.GseItemName
{
    public interface IGseItemNameDto
    {
        public int GseItemNameId { get; set; }
        public string? ItemName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }
    } 
}
