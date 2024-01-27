using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ProcurementStatuses.Requests.Queries
{
    public class GetSelectedProcurementStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
