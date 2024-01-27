using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Districts.Requests.Queries
{
    public class GetSelectedDistrictRequest : IRequest<List<SelectedModel>>
    {
    }
}
