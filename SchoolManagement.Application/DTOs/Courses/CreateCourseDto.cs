namespace SchoolManagement.Application.DTOs.Coursees
{
    public class CreateCourseDto : ICourseDto
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
