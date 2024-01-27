using MediatR;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Commands
{
    public class DeleteDailyAirworthinessFromCategoryCommand : IRequest
    {
        public int DailyAirworthinessFromCategoryId { get; set; }
    }
}
