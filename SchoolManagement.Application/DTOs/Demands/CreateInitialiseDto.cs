using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.Demands;

namespace SchoolManagement.Application.DTOs.ReadingMaterial
{
    public class CreateInitialiseDto
    {
        public IFormFile Doc { get; set; }
        public IFormFile SpecDocument { get; set; }
        public CreateDemandDto DemandForm { get; set; }
    }
}
