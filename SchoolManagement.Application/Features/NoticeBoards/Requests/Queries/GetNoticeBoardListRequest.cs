using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.NoticeBoards;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.NoticeBoards.Requests.Queries
{
    public class GetNoticeBoardListRequest : IRequest<PagedResult<NoticeBoardDto>>
    {
        public QueryParams QueryParams { get; set; } 
        public int? DepartmentNameId { get; set; }
    }
}
