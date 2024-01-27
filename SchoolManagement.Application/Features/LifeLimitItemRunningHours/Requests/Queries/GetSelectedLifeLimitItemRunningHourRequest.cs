using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.LifeLimitItemRunningHours.Requests.Queries
{
    public class GetSelectedLifeLimitItemRunningHourRequest : IRequest<List<SelectedModel>>
    {
    }
}
