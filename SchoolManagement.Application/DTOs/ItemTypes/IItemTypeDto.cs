namespace SchoolManagement.Application.DTOs.ItemTypes
{
    public interface IItemTypeDto
    {
        public int ItemTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
