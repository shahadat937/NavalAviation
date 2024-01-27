using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.MaintenanceSchedule
{
  public class CompletedScheduleMaintDto
  {
    public int MaintenanceScheduleId { get; set; }
    public string? ExtensionGiven { get; set; }
    public string? ProgressBar { get; set; }
    //public string? Doc { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int? CompletedStatus { get; set; }

    public IFormFile? Doc { get; set; }
  }
}
