using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Queries
{
    public class GetSelectedServiceLifeTypeRequest : IRequest<List<SelectedModel>>
    {
    }
} 
