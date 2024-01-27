using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SchoolManagement.Application.DTOs.Attendence
{
  public class CreateAttendanceListDto
  {
    public DateTime AttendanceDate { get; set; }
    public List<TraineeListForm> TraineeListForm { get; set; }
  }
}
