using MediatR;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Commands
{
    public class DeleteDailyAirworthinessFromCommand : IRequest
    {
        public int DailyAirworthinessFromId { get; set; }
    }
}
