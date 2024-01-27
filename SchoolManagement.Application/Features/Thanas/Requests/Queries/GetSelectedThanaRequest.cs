using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Thanas.Requests.Queries
{
    public class GetSelectedThanaRequest : IRequest<List<SelectedModel>>
    {
    }
}
