namespace SchoolManagement.Application.DTOs.Acceptances
{
    public class AcceptanceDto : IAcceptanceDto
    {
        public int AcceptanceId { get; set; }
        public int? ProcurementId { get; set; }
        public int? DemandId { get; set; }
        public int? DemandTypeId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ProcurementStatusId { get; set; }
        public int? SourceOfSupplyId { get; set; }
        public int? ManufactureId { get; set; }
        public int? PrincipalNameId { get; set; }
        public int? PlaceOfDeliveryId { get; set; }
        public int? DemandAuthorityId { get; set; }
        public int? ConditionOfItemId { get; set; }
        public int? SparesCategoryId { get; set; }
        public string? SftLetterNo { get; set; }
        public string? WorkOrderNo { get; set; }
        public DateTime? WorkOrderDate { get; set; }
        public int? SftQty { get; set; }
        public int? Qty { get; set; }
        public int? StoreQtyStatus { get; set; }
        public int? StoreQty { get; set; }
        public int? ProcurementQty { get; set; }
        public string? ItemSerNo { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public DateTime? SftDate { get; set; }
        public string? Warranty { get; set; }
        public DateTime? WarrantyFrom { get; set; }
        public DateTime? WarrantyTo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? ItemInspectionId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string? PurchasePrice { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public string? AcDocument { get; set; }
        public string? ArcDocument { get; set; }
        public string? CofcDocument { get; set; }
        public string? OthersDocument { get; set; }
        public string? SftRegPage { get; set; }
        public string? AcceptanceDocument { get; set; }
        public string? DocVerification { get; set; }
        public int? SftStatus { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? Procurement { get; set; }
        public string? Demand { get; set; }
        public string? DemandType { get; set; }
        public string? DepartmentName { get; set; }
        public string? Condition { get; set; }
        public string? DemandDate { get; set; }
        public string? OuterLatterNo { get; set; }
        public string? ItemDetail { get; set; }
        public string? ItemName { get; set; }
    }
}
