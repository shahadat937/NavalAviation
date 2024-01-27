using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NameofPublication
{
    public class CreateNameofPublicationDto : INameofPublicationDto
    {
        public int NameofPublicationId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Name { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
