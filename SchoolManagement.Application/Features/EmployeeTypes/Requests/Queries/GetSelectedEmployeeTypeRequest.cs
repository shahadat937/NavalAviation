using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.EmployeeTypes.Requests.Queries
{
    public class GetSelectedEmployeeTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
