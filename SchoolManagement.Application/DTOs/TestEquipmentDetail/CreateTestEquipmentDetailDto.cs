using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TestEquipmentDetail
{
    public class CreateTestEquipmentDetailDto : ITestEquipmentDetailDto
    {
    public int TestEquipmentDetailId { get; set; }
    public int? ShopId { get; set; }
    public string? EquipmentName { get; set; }
    public string? PattNo { get; set; }
    public string? Deno { get; set; }
    public int? Qty { get; set; }
    public string? ShelfLife { get; set; }
    public string? Remarks { get; set; }
    public int? MenuPosition { get; set; }
    public bool IsActive { get; set; }
  }
}
