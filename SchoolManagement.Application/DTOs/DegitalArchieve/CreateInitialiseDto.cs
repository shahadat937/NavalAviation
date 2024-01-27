using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.DegitalArchieve;

namespace SchoolManagement.Application.DTOs.DegitalArchieve
{
    public class CreateInitialiseDto
    {
        public IFormFile Document { get; set; }
        public CreateDegitalArchieveDto DegitalArchieveForm { get; set; }
    }
}
