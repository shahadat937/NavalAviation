using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Domain;
using System.IO;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.DTOs.NoticeBoards;

namespace SchoolManagement.Application.Helpers
{
    public class NoticeBoardFileUrlResolver : IValueResolver<NoticeBoard, NoticeBoardDto, string>
    {

        private readonly IConfiguration _config;
        public NoticeBoardFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(NoticeBoard source, NoticeBoardDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.NoticeDocument))
            {

                return _config["ApiUrl"] + source.NoticeDocument;
            }
           

            return null;
        }
        
    }
    
}
