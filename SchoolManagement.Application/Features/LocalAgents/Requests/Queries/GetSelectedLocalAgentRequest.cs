using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.LocalAgents.Requests.Queries
{
    public class GetSelectedLocalAgentRequest : IRequest<List<SelectedModel>>
    {
    }
}
