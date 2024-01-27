using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Requests.Queries
{
    public class GetSelectedOverhaulingTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
