using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Commands
{
    public class CreateDailyAirworthinessFromCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateDailyAirworthinessFromCategoryDto DailyAirworthinessFromCategoryDto { get; set; }
    }
}
