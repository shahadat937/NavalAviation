using MediatR;
using SchoolManagement.Application.DTOs.NoticeBoards;

namespace SchoolManagement.Application.Features.NoticeBoards.Requests.Queries
{
    public class GetNoticeBoardDetailRequest : IRequest<NoticeBoardDto>
    {
        public int NoticeBoardId { get; set; }
    }
}
