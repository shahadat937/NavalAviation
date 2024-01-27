using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.Thana
{
    public class ThanaDto : IThanaDto
    {


        public int ThanaId { get; set; }
        public int DistrictId { get; set; }
        public string ThanaName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? District { get; set; }

    }
}
