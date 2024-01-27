using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.GseItemNames.Requests.Queries
{
    public class GetSelectedGseItemNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
