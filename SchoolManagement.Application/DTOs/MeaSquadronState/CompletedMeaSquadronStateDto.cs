using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.MeaSquadronState
{
  public class CompletedMeaSquadronStateDto
  {
    public int MeaSquadronStateId { get; set; }
    public int? MeaWorkShopId { get; set; }
    public string? ControlNo { get; set; }
  }
}
