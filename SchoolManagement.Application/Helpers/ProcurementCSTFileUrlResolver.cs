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
    public class ProcurementCSTFileUrlResolver : IValueResolver<Procurement, ProcurementDto, string>
    {

        private readonly IConfiguration _config;
        public ProcurementCSTFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Procurement source, ProcurementDto destination, string destMember, ResolutionContext context)
        {
           

            if (!string.IsNullOrEmpty(source.TenderNotice))
            {

                return _config["ApiUrl"] + source.TenderNotice;
            }


            return null;
        }
        
    }
    
}
