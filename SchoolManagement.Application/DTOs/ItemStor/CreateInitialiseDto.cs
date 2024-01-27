using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.ItemStor;

namespace SchoolManagement.Application.DTOs.ItemStor
{
    public class CreateInitialiseDto
    {
        public IFormFile Doc { get; set; }
        public CreateItemStorDto ItemStorForm { get; set; }
    }
}
