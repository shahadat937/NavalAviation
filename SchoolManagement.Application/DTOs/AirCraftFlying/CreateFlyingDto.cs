using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.AirCraftFlying;

namespace SchoolManagement.Application.DTOs.ReadingMaterial
{
    public class CreateFlyingDto
    {
        public IFormFile Doc { get; set; }
        public CreateAirCraftFlyingDto AirCraftFlyingForm { get; set; }
    }
}
