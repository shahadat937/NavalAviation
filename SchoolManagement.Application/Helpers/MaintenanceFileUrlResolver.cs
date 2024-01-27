using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenancePlanning;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class MaintenanceFileUrlResolver : IValueResolver<MaintenancePlanning, MaintenancePlanningDto,  string>
    {
        private readonly IConfiguration _config;
        public MaintenanceFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(MaintenancePlanning source, MaintenancePlanningDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.JobListDocument))
            {

                return _config["ApiUrl"] + source.JobListDocument;
            }


            return null;
        }


    }
}
