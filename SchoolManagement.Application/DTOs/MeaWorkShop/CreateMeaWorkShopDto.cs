using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.MeaWorkShop
{
    public class CreateMeaWorkShopDto : IMeaWorkShopDto
    {
        public int MeaWorkShopId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? Position { get; set; }
        public bool IsActive { get; set; }
     }
}
