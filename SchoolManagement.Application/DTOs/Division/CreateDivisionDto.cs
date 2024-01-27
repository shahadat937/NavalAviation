using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.Division
{
    public class CreateDivisionDto : IDivisionDto
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
