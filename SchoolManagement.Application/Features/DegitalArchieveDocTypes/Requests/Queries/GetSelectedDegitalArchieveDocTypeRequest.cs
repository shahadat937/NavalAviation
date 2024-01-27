using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Queries
{
    public class GetSelectedDegitalArchieveDocTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
