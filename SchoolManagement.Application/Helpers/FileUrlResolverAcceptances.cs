using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.Acceptances;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class FileUrlResolverAcceptances : IValueResolver<Acceptance, AcceptanceDto, string>
    {
        private readonly IConfiguration _config;
        public FileUrlResolverAcceptances(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Acceptance source, AcceptanceDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.AcceptanceDocument))
            {

                return _config["ApiUrl"] + source.AcceptanceDocument;
            }


            return null;
        }
    }
}
