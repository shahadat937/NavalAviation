using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.District
{
    public interface IDistrictDto
    {
        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public string DistrictName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
