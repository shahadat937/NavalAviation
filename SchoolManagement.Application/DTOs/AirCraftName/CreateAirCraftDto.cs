using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.AirCraftName
{
    public class CreateAirCraftDto
    {
        

        public IFormFile Photo { get; set; }
        public CreateAirCraftNameDto AirCraftNameForm { get; set; }
}
}
