using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Domain;
using System.IO;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.DTOs.Procurement;

namespace SchoolManagement.Application.Helpers
{
    public class ProcurementFileUrlResolver : IValueResolver<Procurement, ProcurementDto, string>
    {

        private readonly IConfiguration _config;
        public ProcurementFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Procurement source, ProcurementDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.TenderSpecification))
            {

                return _config["ApiUrl"] + source.TenderSpecification;
            }
           

            return null;
        }
        
    }
    
}
