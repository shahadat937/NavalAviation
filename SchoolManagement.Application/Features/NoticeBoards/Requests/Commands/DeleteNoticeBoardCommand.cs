using MediatR;

namespace SchoolManagement.Application.Features.NoticeBoards.Requests.Commands
{
    public class DeleteNoticeBoardCommand : IRequest
    {
        public int NoticeBoardId { get; set; }
    }
} 
