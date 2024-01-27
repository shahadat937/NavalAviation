using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Procurement : BaseDomainEntity
    {
        public Procurement()
        {
            Acceptances = new HashSet<Acceptance>();
            ItemReminders = new HashSet<ItemReminder>();
            ItemStors = new HashSet<ItemStor>();
        }

        public int ProcurementId { get; set; }
        public int? DemandId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ProcurementStatusId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? PrincipalNameId { get; set; }
        public int? ManufactureId { get; set; }
        public int? CstTecId { get; set; }
        public int? LocalAgentId { get; set; }
        public int? SupplierId { get; set; }
        public int? DemandTypeId { get; set; }
        public int? SupplierAId { get; set; }
        public int? SupplierMId { get; set; }
        public int? PartOfShipmentId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? SftQty { get; set; }
        public string? TenderNumber { get; set; }
        public string? Reason { get; set; }
        public string? LatestProgress { get; set; }
        public DateTime? DateOfTenderFloat { get; set; }
        public DateTime? TenderopeningDate { get; set; }
        public DateTime? TenderPublishDate { get; set; }
        public string? TenderNotice { get; set; }
        public string? TenderSpecification { get; set; }
        public string? FinancialApproval { get; set; }
        public string? WorkOrder { get; set; }
        public DateTime? WorkOrderDate { get; set; }
        public DateTime? DateOfDelivery { get; set; }
        public string? UnitPrice { get; set; }
        public string? Qty { get; set; }
        public int? ProcurementCompleteStatus { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string? Remarks { get; set; }
        public string? ProcurementDocument { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CstTec? CstTec { get; set; }
        public virtual Demand? Demand { get; set; }
        public virtual DemandType? DemandType { get; set; }
        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual LocalAgent? LocalAgent { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual PartOfShipment? PartOfShipment { get; set; }
        public virtual ItemCategory? ItemCategory { get; set; }
        public virtual PrincipalName? PrincipalName { get; set; }
        public virtual Manufacture? Manufacture { get; set; }
        public virtual ProcurementStatus? ProcurementStatus { get; set; }
        public virtual SparesCategory? SparesCategory { get; set; }
        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<ItemReminder> ItemReminders { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
    }
}
