using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.Demands;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class FileSpecUrlResolver : IValueResolver<Demand, DemandDto,  string>
    {
        private readonly IConfiguration _config;
        public FileSpecUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Demand source, DemandDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.SpecDoc))
            {

                return _config["ApiUrl"] + source.SpecDoc;
            }


            return null;
        }


    }
}
