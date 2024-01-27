using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.ArchivingforPublication;

namespace SchoolManagement.Application.DTOs.ArchivingforPublication
{
    public class CreateInitialiseDto
    {
        public IFormFile Document { get; set; }
        public CreateArchivingforPublicationDto ArchivingforPublicationForm { get; set; }
    }
}
