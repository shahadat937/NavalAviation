using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Domain;
using System.IO;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.DTOs.MeaSquadronState;

namespace SchoolManagement.Application.Helpers
{
    public class MeaSquadronStateFileUrlResolver : IValueResolver<MeaSquadronState, MeaSquadronStateDto, string>
    {

        private readonly IConfiguration _config;
        public MeaSquadronStateFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(MeaSquadronState source, MeaSquadronStateDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.DocUpload))
            {

                return _config["ApiUrl"] + source.DocUpload;
            }
           

            return null;
        }
        
    }
    
}
