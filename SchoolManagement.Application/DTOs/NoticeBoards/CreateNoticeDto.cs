using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.NoticeBoards;
using SchoolManagement.Application.DTOs.Procurement;

namespace SchoolManagement.Application.DTOs.NoticeBoards
{
  public class CreateNoticeDto 
  {
    public IFormFile Doc { get; set; }
    public CreateNoticeBoardDto NoticeBoardForm { get; set; }
  }
} 
