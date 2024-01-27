using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.GseScheduleWorkTypes.Requests.Queries
{
    public class GetSelectedGseScheduleWorkTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
