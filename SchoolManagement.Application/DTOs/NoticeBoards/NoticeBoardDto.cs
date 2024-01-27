using SchoolManagement.Application.DTOs.NoticeBoards;

namespace SchoolManagement.Application.DTOs.NoticeBoards
{
    public class NoticeBoardDto : INoticeBoardDto
    {
        public int NoticeBoardId { get; set; }
        public int? DepartmentNameId { get; set; }
        public DateTime? Date { get; set; }
        public string? Event { get; set; }
        public string? OrderBy { get; set; }
        public string? Remarks { get; set; } 
        public bool IsActive { get; set; }
        public string? DepartmentName { get; set; }
        public string? NoticeDocument { get; set; }
  }
}
