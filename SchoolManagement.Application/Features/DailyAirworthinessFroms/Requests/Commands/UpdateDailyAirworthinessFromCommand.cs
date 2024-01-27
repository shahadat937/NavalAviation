using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Commands
{
    public class UpdateDailyAirworthinessFromCommand : IRequest<Unit>
    {
        public CreateDailyAirworthinessFromDto UpdateDailyAirworthinessFromDto { get; set; }
    }
}
