using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class AirworthinessFromFileUrlResolver : IValueResolver<DailyAirworthinessFrom, DailyAirworthinessFromDto,  string>
    {
        private readonly IConfiguration _config;
        public AirworthinessFromFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(DailyAirworthinessFrom source, DailyAirworthinessFromDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Doc))
            {

                return _config["ApiUrl"] + source.Doc;
            }


            return null;
        }


    }
}
