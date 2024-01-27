using MediatR;
using SchoolManagement.Application.DTOs.NoticeBoards;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.NoticeBoards.Requests.Commands
{
    public class CreateNoticeBoardCommand : IRequest<BaseCommandResponse>
    {
        public CreateNoticeBoardDto NoticeBoardDto { get; set; }
    }
}
