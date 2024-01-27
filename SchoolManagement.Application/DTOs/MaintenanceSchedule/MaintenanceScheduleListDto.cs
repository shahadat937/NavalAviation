using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenanceSchedule
{
    public class MaintenanceScheduleListDto
    {
        public int? Serial { get; set; }
        public string? Name { get; set; }        
        public DateTime? LastInspDate { get; set; }
        public string? LastInspectionFH { get; set; }
        public string? LastInspectionOH { get; set; }
        
    }
}
