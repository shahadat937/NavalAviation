using MediatR;
using SchoolManagement.Application.DTOs.NoticeBoards;
using SchoolManagement.Application.DTOs.NoticeBoards;

namespace SchoolManagement.Application.Features.NoticeBoards.Requests.Commands
{
    public class UpdateNoticeBoardCommand : IRequest<Unit>
    { 
        public CreateNoticeBoardDto UpdateNoticeBoardDto { get; set; }
    }
}
