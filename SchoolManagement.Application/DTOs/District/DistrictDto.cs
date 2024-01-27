using System;

namespace SchoolManagement.Application.DTOs.District
{
    public class DistrictDto : IDistrictDto
    {
        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public string DistrictName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? Division { get; set; }
    }
}
