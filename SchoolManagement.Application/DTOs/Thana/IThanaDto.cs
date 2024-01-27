using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Thana
{
    public interface IThanaDto
    {
        public int ThanaId { get; set; }
        public int DistrictId { get; set; }
        public string ThanaName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
