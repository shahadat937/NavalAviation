using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Caste
{
    public interface ICasteDto
    {
        public int CasteId { get; set; }
        public int ReligionId { get; set; }
        public string CastName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
