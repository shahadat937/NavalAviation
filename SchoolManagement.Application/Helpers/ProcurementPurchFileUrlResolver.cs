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
    public class ProcurementPurchFileUrlResolver : IValueResolver<Procurement, ProcurementDto, string>
    {

        private readonly IConfiguration _config;
        public ProcurementPurchFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Procurement source, ProcurementDto destination, string destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.ProcurementDocument))
            {

                return _config["ApiUrl"] + source.ProcurementDocument;
            }

            return null;
        }
        
    }
    
}
