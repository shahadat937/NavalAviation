using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Denos.Requests.Queries
{
    public class GetSelectedDenoRequest : IRequest<List<SelectedModel>>
    {
    }
} 
