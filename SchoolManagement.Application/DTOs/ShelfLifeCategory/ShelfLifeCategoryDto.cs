using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ShelfLifeCategory
{
    public class ShelfLifeCategoryDto : IShelfLifeCategoryDto
    {
        public int ShelfLifeCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }
    }
}
