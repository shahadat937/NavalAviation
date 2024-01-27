using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries
{
    public class GetSelectedDegitalArchieveRequest : IRequest<List<SelectedModel>>
    {
    }
}
