using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Requests.Queries
{
    public class GetSelectedSourceOfSupplyRequest : IRequest<List<SelectedModel>>
    {
    }
}
