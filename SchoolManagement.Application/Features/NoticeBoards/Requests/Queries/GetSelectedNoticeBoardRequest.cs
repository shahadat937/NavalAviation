using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.NoticeBoards.Requests.Queries
{
    public class GetSelectedNoticeBoardRequest : IRequest<List<SelectedModel>>
    {
    }
} 
