using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.MeaBlankFormat;

namespace SchoolManagement.Application.DTOs.MeaBlankFormat
{
    public class CreateInitialiseDto
    {
        public IFormFile Document { get; set; }
        public CreateMeaBlankFormatDto MeaBlankFormatForm { get; set; }
    }
}
