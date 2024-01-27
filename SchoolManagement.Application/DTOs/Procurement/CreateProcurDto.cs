using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.Procurement
{
    public class CreateProcurDto
    {
        

        public IFormFile Doc { get; set; }
        public IFormFile Notice { get; set; }
        public IFormFile PrDoc { get; set; }
        public CreateProcurementDto ProcurementForm { get; set; }
}
}
