using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Queries
{
    public class GetDailyAirworthinessFromDetailRequest : IRequest<DailyAirworthinessFromDto>
    {
        public int DailyAirworthinessFromId { get; set; }
    }
}
