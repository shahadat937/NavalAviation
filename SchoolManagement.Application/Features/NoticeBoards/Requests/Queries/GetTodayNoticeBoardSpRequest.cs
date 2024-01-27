using MediatR;

namespace SchoolManagement.Application.Features.NoticeBoards.Requests.Queries
{
    public class GetTodayNoticeBoardSpRequest : IRequest<object>
    {
      public int DepartmentId { get; set; }
    }
}
