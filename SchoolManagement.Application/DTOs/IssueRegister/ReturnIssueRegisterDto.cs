using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.IssueRegister
{
  public class ReturnIssueRegisterDto
  {
    public int IssueRegisterId { get; set; }
    public int ItemStoreId { get; set; }
    public int? IssueStatusId { get; set; }
    public int? IssueQty { get; set; }
    public int? ReturningQty { get; set; }
  }
}
