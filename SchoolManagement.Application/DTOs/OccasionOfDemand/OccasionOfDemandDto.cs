using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OccasionOfDemand
{
    public class OccasionOfDemandDto : IOccasionOfDemandDto
    {
        public int OccasionOfDemandId { get; set; }
        public string? Name { get; set; }
        public int? FiscalYearId { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public string? FiscalYear { get; set; }
    }
}
