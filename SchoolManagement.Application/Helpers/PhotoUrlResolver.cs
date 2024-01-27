using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SchoolManagement.Domain;
using System.IO;
using SchoolManagement.Application.DTOs.AirCraftName;

namespace SchoolManagement.Application.Helpers
{
    public class PhotoUrlResolver : IValueResolver<AirCraftName, AirCraftNameDto, string>
    {
        //private readonly IConfiguration _config;
        //public PhotoUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        public string Resolve(AirCraftName source, AirCraftNameDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Image))
            {

                return "https://localhost:44395/Content/" + source.Image;
            }

            return null;
        }
    }
}
