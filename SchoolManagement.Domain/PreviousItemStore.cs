using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class PreviousItemStore : BaseDomainEntity
    {
        

        public int PreviousItemStoreId { get; set; }
        public int? AcceptanceId { get; set; }
        public int? ProcurementId { get; set; }
        public int? DemandId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ToolsBoxNameId { get; set; }
        public int? ToolsLocationId { get; set; }
        public int? ToolsTypeId { get; set; }
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
        public int? AvailableQty { get; set; }
        public string? Location { get; set; }
        public string? ServiceLife { get; set; }
        public string? EndLifeTime { get; set; }
        public string? Accessories { get; set; }
        public string? StockRegisterPageNo { get; set; }
        public string? RetirmentLife { get; set; }
        public string? Remarks { get; set; }
        public bool? ArcDoc { get; set; }
        public bool? CofcDoc { get; set; }
        public bool? OtherDoc { get; set; }
        public bool? OemDoc { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? DemandQty { get; set; }
        public DateTime? DemandDate { get; set; }
        public string? LetterOuterNo { get; set; }
        public string? RefPoNo { get; set; }
        public string? TenderNumber { get; set; }
        public DateTime? DateOfTenderFloat { get; set; }
        public DateTime? TenderopeningDate { get; set; }
        public DateTime? TenderPublishDate { get; set; }
        public string? TenderNotice { get; set; }
        public DateTime? CalibrationDate { get; set; }
        public DateTime? NextCalibrationDate { get; set; }

        //public virtual Acceptance? Acceptance { get; set; }
        public virtual AcctStore? AcctStore { get; set; }
        //public virtual Demand? Demand { get; set; }
        public virtual Deno? Deno { get; set; }
        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual EndLifeType? EndLifeType { get; set; }
        public virtual ItemCategory? ItemCategory { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual OverhaulingType? OverhaulingType { get; set; }
        //public virtual Procurement? Procurement { get; set; }
        public virtual RetirementType? RetirementType { get; set; }
        public virtual ServiceLifeType? ServiceLifeType { get; set; }
        public virtual SparesCategory? SparesCategory { get; set; }
        public virtual ToolsBoxName? ToolsBoxName { get; set; }
        public virtual ToolsLocation? ToolsLocation { get; set; }
        public virtual ToolsType? ToolsType { get; set; }
       
    }
}
