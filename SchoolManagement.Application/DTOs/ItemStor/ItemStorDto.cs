using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ItemStor
{
    public class ItemStorDto : IItemStorDto
    {
        public int ItemStorId { get; set; }
        public int? AcceptanceId { get; set; }
        public int? ProcurementId { get; set; }
        public int? DemandId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ToolsBoxNameId { get; set; }
        public int? ToolsLocationId { get; set; }
        public int? ConditionOfItemId { get; set; }
        public int? LifeLimitItemId { get; set; }
        public int? ToolsTypeId { get; set; }
        public int? ProcurementStatusId { get; set; }
        public int? DenoId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? ServiceLifeTypeId { get; set; }
        public int? EndLifeTypeId { get; set; }
        public int? AcctStoreId { get; set; }
        public int? OverhaulingTypeId { get; set; }
        public int? RetirementTypeId { get; set; }
        public string? ItemSerNo { get; set; }
        public string? IcmNo { get; set; }
        public string? ShelfLife { get; set; }
        public string? EndShalfLife { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public DateTime? ItemReceivedDate { get; set; }
        public int? TotalReceivedQty { get; set; }
        public int? IssuedQty { get; set; }
        public int? NsdQty { get; set; }
        public int? AvailableQty { get; set; }
        public string? Location { get; set; }
        public string? ServiceLife { get; set; }
        public string? EndLifeTime { get; set; }
        public string? Accessories { get; set; }
        public string? StockRegisterPageNo { get; set; }
        public string? RetirmentLife { get; set; }
        public double? OldPrice { get; set; }
        public string? Remarks { get; set; }
        public bool? ArcDoc { get; set; }
        public bool? CofcDoc { get; set; }
        public string? OtherDoc { get; set; }
        public bool? OemDoc { get; set; }
        public int? Status { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? DemandQty { get; set; }
        public DateTime? DemandDate { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string? LetterOuterNo { get; set; }
        public string? RefPoNo { get; set; }
        public string? TenderNumber { get; set; }
        public DateTime? DateOfTenderFloat { get; set; }
        public DateTime? TenderopeningDate { get; set; }
        public DateTime? TenderPublishDate { get; set; }
        public string? TenderNotice { get; set; }
        public DateTime? CalibrationDate { get; set; }
        public DateTime? NextCalibrationDate { get; set; }
        public int? PermanentQty { get; set; }
        public int? TYQty { get; set; }
        public int? RepairQty { get; set; }
        public int? SurveyQty { get; set; }
        public int? AircraftFittedQty { get; set; }
        public int? MaintenanceQty { get; set; }
        public int? CalibrationQty { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public DateTime? LastCalibrationDate { get; set; }
        public DateTime? NextMaintenenceDate { get; set; }

        public string? ToolsType { get; set; }
        public string? TenderSpecification { get; set; }
        public string? ItemDetail { get; set; }
        public string? AcctStore { get; set; }
        public string? DepartmentName { get; set; }
        public string? PartNo { get; set; }
        public string? NameOfItem { get; set; }
        public string? Deno { get; set; }
        public string? LifeLimitItem { get; set; }
        public string? SparesCategory { get; set; }
        public string? Condition { get; set; }
        public string? ToolsLocation { get; set; }
        public string? ToolsBoxName { get; set; }

    }
}
