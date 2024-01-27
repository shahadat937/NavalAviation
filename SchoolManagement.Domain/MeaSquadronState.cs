using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class MeaSquadronState : BaseDomainEntity 
  {

        public int MeaSquadronStateId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? PresentStateId { get; set; }
        public int? TradeId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ConditionOfItemId { get; set; }
        public int? MeaWorkShopId { get; set; }
        public string? ModelNo { get; set; }
        public string? RegistrationNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? TotalhouratDelivey { get; set; }
        public string? TotalHouratOccation { get; set; }
        public int? Qty { get; set; }
        public string? ControlNo { get; set; }
        public string? AtaCode { get; set; }
        public DateTime? DateofInstall { get; set; }
        public string? TotalLandingCycles { get; set; }
        public string? TotalAcHour { get; set; }
        public string? ResonForRemoval { get; set; }
        public string? Description { get; set; }
        public string? WorkOrderNo { get; set; }
        public DateTime? DateofSubmition { get; set; }
        public DateTime? DateOfDiscrepancy { get; set; }
        public string? SerNo { get; set; }
        public string? WorkOrderReceived { get; set; }
        public DateTime? WorkOrderDate { get; set; }
        public string? WorkshopName { get; set; }
        public string? Remarks { get; set; }
        public string? DocUpload { get; set; }
        public int? JobStatus { get; set; }
        public int? WorkCompletedStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual ConditionOfItem? ConditionOfItem { get; set; }
        public virtual Trade? Trade { get; set; }
        public virtual MeaWorkShop? MeaWorkShop { get; set; }

        public virtual PresentState? PresentState { get; set; }

    }
}
