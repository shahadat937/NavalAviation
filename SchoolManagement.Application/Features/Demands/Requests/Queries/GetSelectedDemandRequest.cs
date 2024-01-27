using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Demands.Requests.Queries
{
    public class GetSelectedDemandRequest : IRequest<List<SelectedModel>>
    {
    }
} 
