using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Store
{
    public class StoreDto : IStoreDto
    {
        public int StoreId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
