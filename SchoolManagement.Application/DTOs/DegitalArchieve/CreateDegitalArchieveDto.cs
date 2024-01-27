using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DegitalArchieve
{
    public class CreateDegitalArchieveDto : IDegitalArchieveDto
    {
        public int DegitalArchieveId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? DegitalArchieveDocTypeId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfLastRev { get; set; }
        public string? Doc { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? Document { get; set; }
    }
}
