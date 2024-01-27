using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemStatuses.Requests.Queries
{
    public class GetSelectedItemStatusRequest : IRequest<List<SelectedModel>>
    {
    }
} 
