using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Division
{
    public interface IDivisionDto
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
