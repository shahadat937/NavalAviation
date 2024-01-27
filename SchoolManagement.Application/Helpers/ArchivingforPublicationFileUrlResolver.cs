using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class ArchivingforPublicationFileUrlResolver : IValueResolver<ArchivingforPublication, ArchivingforPublicationDto,  string>
    {
        private readonly IConfiguration _config;
        public ArchivingforPublicationFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ArchivingforPublication source, ArchivingforPublicationDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.DocUpload))
            {

                return _config["ApiUrl"] + source.DocUpload;
            }


            return null;
        }


    }
}
