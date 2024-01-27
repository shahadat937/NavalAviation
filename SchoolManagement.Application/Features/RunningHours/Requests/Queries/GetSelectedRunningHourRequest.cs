using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.RunningHours.Requests.Queries
{
    public class GetSelectedRunningHourRequest : IRequest<List<SelectedModel>>
    {
    }
}
