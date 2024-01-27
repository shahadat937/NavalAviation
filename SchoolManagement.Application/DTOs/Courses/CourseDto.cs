using SchoolManagement.Application.DTOs.Coursees;

namespace SchoolManagement.Application.DTOs.Courses
{
    public class CourseDto : ICourseDto
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
