using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Commands
{
    public class CreateDailyAirworthinessFromCommand : IRequest<BaseCommandResponse>
    {
        public CreateDailyAirworthinessFromDto DailyAirworthinessFromDto { get; set; }
    }
}
