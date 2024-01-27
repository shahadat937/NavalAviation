using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.EndLifeTypes.Requests.Queries
{
    public class GetSelectedEndLifeTypeRequest : IRequest<List<SelectedModel>>
    {
    }
} 
