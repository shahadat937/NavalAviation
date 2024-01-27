using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Queries
{
    public class GetSelectedAcStatusRequest : IRequest<List<SelectedModel>>
    {
    }
} 
