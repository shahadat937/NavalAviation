using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MaintenanceType
{
    public class CreateMaintenanceTypeDto : IMaintenanceTypeDto
    {
        public int MaintenanceTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }
    }
}
