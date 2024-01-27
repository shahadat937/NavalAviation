using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Attendence
{
  public class TraineeListForm
  { 
    public int DepartmentNameId { get; set; } 
    public bool AttendanceStatus { get; set; }
    public int TrainingCrewId { get; set; }
    public int? SailorRankId { get; set; }
    public int? OfficersStatusId { get; set; }
  }
}
