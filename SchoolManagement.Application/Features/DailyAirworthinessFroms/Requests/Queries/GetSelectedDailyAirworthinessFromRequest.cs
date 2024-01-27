using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries
{
    public class GetSelectedDailyAirworthinessFromRequest : IRequest<List<SelectedModel>>
    {
    }
}
