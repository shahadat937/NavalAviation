using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory
{
    public class DailyAirworthinessFromCategoryDto : IDailyAirworthinessFromCategoryDto
    {
        public int DailyAirworthinessFromCategoryId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }
        public string? DepartmentName { get; set; }

     }
}
