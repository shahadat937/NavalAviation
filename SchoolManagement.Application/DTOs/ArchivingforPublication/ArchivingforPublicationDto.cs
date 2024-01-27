using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ArchivingforPublication
{
    public class ArchivingforPublicationDto : IArchivingforPublicationDto
    {
        public int ArchivingforPublicationId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? NameofPublicationId { get; set; }
        public string? DocumentName { get; set; }
        public DateTime? Date { get; set; }
        public string? DocUpload { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }
        public string? DepartmentName { get; set; }
        public string? AircraftName { get; set; }
        public string? NameofPublication { get; set; }
    }
}
