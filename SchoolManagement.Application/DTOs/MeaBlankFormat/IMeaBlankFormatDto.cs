using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MeaBlankFormat
{
    public interface IMeaBlankFormatDto
    {
        public int MeaBlankFormatId { get; set; }
        public string? Name { get; set; }
        public string? Doc { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
     } 
}
