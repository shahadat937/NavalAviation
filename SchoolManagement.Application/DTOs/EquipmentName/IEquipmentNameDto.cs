namespace SchoolManagement.Application.DTOs.EquipmentName
{
    public interface IEquipmentNameDto
    {
        public int EquipmentNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? SparesCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
