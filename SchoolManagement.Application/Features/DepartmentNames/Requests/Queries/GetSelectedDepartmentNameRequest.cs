using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DepartmentNames.Requests.Queries
{
    public class GetSelectedDepartmentNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
