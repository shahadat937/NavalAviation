using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.DTOs.Demands;

namespace SchoolManagement.Application.DTOs.Acceptances
{
    public class CreateInitialiseDto 
    {
        public IFormFile Doc { get; set; }
        public CreateAcceptanceDto AcceptanceForm { get; set; }
    }
} 
