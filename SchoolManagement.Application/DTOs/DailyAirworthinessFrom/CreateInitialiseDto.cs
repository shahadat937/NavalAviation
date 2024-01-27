using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;

namespace SchoolManagement.Application.DTOs.DailyAirworthinessFrom
{
    public class CreateInitialiseDto
    {
        public IFormFile Document { get; set; }
        public CreateDailyAirworthinessFromDto DailyAirworthinessFromForm { get; set; }
    }
}
