using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DepartmentName
{
    public class CreateDepartmentNameDto : IDepartmentNameDto
    {
        public int DepartmentNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
