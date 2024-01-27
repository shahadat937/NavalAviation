using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class DegitalArchieveFileUrlResolver : IValueResolver<DegitalArchieve, DegitalArchieveDto,  string>
    {
        private readonly IConfiguration _config;
        public DegitalArchieveFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(DegitalArchieve source, DegitalArchieveDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Doc))
            {

                return _config["ApiUrl"] + source.Doc;
            }


            return null;
        }


    }
}
