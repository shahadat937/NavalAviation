namespace SchoolManagement.Application.DTOs.ItemCategorys
{
    public interface IItemCategoryDto
    {
        public int ItemCategoryId { get; set; }
        public int? SparesCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
