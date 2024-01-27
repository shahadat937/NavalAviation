using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Shop
{
    public class CreateShopDto : IShopDto
    {
    public int ShopId { get; set; }
    public string? Name { get; set; }
    public int? MenuPosition { get; set; }
    public string? Remarks { get; set; }
    public bool IsActive { get; set; }
  }
}
