using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Rank
{
    public class RankDto : IRankDto
    {
        public int RankId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
