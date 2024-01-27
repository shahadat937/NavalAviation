using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Statuses.Requests.Queries
{
    public class GetSelectedStatusRequest : IRequest<List<SelectedModel>>
    {
    }
} 
