using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.DegitalArchieveDocType
{
    public class DegitalArchieveDocTypeDto : IDegitalArchieveDocTypeDto
    {
        public int DegitalArchieveDocTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
     }
}
