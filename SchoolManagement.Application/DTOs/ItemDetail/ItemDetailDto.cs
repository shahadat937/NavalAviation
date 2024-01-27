using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ItemDetail
{
    public class ItemDetailDto : IItemDetailDto
    {
        public int ItemDetailId { get; set; }
        public int? EquipmentNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? EquipmentOrSystemName { get; set; }
        public string? PartNo { get; set; }
        public string? ImcNumber { get; set; }
        public string? SerialNo { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? NameOfItem { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? ItemCategoryTypeId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? ItemTypeId { get; set; }
        public string? AlternatiovePrartNo { get; set; }
        public string? MinimumStock { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public int? TradeId { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public int? MaintananceState { get; set; }
        public int? CalibrationState { get; set; }
        public bool IsActive { get; set; }



        public string? DepartmentName { get; set; }
        public string? Trade { get; set; }
    }
}
