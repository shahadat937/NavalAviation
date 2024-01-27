namespace SchoolManagement.Application.DTOs.SparesCategorys
{
    public class CreateSparesCategoryDto : ISparesCategoryDto
    {
        public int SparesCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
