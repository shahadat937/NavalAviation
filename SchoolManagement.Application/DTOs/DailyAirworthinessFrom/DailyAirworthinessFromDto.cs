using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DailyAirworthinessFrom
{
    public class DailyAirworthinessFromDto : IDailyAirworthinessFromDto
    {
        public int DailyAirworthinessFromId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? DailyAirworthinessFromCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Doc { get; set; }

        public int? DocType { get; set; }
        public DateTime? UploadDate { get; set; }

        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? DepartmentName { get; set; }
        public string? FromCategory { get; set; }
        public string? AircraftName { get; set; }
     }
}
