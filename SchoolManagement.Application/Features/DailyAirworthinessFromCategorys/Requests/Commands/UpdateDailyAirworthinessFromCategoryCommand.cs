using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Commands
{
    public class UpdateDailyAirworthinessFromCategoryCommand : IRequest<Unit>
    {
        public DailyAirworthinessFromCategoryDto DailyAirworthinessFromCategoryDto { get; set; }
    }
}
