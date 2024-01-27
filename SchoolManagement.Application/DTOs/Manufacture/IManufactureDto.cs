using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Manufacture
{
    public interface IManufactureDto
    {
        public int ManufactureId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    } 
}
