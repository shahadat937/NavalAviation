using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RunningHour
{
    public class RunningHourDto : IRunningHourDto
    {
        public int RunningHourId { get; set; }
        public int? AirCraftNameId { get; set; }
        public DateTime? FlightDate { get; set; }
        public string? FlightTimeHr { get; set; }
        public string? FlightTimeMin { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public string? AirCraftName { get; set; }
        public string? DepartmentName { get; set; }


    }
}
