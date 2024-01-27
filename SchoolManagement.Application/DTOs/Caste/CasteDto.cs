using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.Caste
{
    public class CasteDto : ICasteDto
    {
        public int CasteId { get; set; }
        public int ReligionId { get; set; }
        public string CastName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? Religion { get; set; }
    }
}
