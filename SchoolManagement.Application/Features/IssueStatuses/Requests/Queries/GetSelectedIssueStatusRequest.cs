using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueStatuses.Requests.Queries
{
    public class GetSelectedIssueStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
