using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DemandType
{
    public class CreateDemandTypeDto : IDemandTypeDto
    {
        public int DemandTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
