using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Manufactures.Requests.Queries
{
    public class GetSelectedManufactureRequest : IRequest<List<SelectedModel>>
    {
    }
}
