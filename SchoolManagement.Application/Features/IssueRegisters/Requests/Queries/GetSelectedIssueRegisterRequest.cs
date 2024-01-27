using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.IssueRegisters.Requests.Queries
{
    public class GetSelectedIssueRegisterRequest : IRequest<List<SelectedModel>>
    {
    }
}
