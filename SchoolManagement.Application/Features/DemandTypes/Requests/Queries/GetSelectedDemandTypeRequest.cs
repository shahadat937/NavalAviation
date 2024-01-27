using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandTypes.Requests.Queries
{
    public class GetSelectedDemandTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
