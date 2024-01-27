namespace SchoolManagement.Application.DTOs.EquipmentName
{
    public class EquipmentNameDto : IEquipmentNameDto
    {
        public int EquipmentNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? SparesCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public string? DepartmentName { get; set; }
    }
}
