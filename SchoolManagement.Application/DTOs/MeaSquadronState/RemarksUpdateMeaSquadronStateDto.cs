using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.MeaSquadronState
{
  public class RemarksUpdateMeaSquadronStateDto
  {
    public int MeaSquadronStateId { get; set; }
    public string? Remarks { get; set; }
    
  }
}
