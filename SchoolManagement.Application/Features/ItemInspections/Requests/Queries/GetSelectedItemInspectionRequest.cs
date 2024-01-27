using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemInspections.Requests.Queries
{
    public class GetSelectedItemInspectionRequest : IRequest<List<SelectedModel>>
    {
    }
}
