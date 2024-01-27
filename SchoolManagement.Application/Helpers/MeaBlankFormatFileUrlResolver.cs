using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class MeaBlankFormatFileUrlResolver : IValueResolver<MeaBlankFormat, MeaBlankFormatDto,  string>
    {
        private readonly IConfiguration _config;
        public MeaBlankFormatFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(MeaBlankFormat source, MeaBlankFormatDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Doc))
            {

                return _config["ApiUrl"] + source.Doc;
            }


            return null;
        }


    }
}
