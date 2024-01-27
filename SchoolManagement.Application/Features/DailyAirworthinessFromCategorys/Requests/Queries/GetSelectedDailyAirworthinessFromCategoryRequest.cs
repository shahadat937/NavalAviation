using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries
{
    public class GetSelectedDailyAirworthinessFromCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
