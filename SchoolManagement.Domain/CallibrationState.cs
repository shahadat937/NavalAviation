using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class CallibrationState : BaseDomainEntity
    {

        public int CallibrationStateId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemStoreId { get; set;}
        public int? TradeId { get; set; }
        public string? SerNo { get; set; }
        public string? ItemName { get; set; }
        public DateTime? LastDateofCalibrated { get; set; } 
       // public DateTime? CompletedDate { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? PresentState { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual Trade? Trade { get; set; }

    }
}
