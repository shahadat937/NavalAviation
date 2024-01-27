using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Religion
{
    public interface IReligionDto
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
