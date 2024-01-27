using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.District
{
    public class CreateDistrictDto : IDistrictDto
    {
        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public string DistrictName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
