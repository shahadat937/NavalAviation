using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ToolsLocation 
{
    public class ToolsLocationDto : IToolsLocationDto
    { 
        public int ToolsLocationId { get; set; }
        public string? ToolsLocationName { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
