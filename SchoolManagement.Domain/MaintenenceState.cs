using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public class MaintenenceState :BaseDomainEntity
    {
        public int MaintenenceStateId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ItemStoreId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? TradeId { get; set; }
        public string? SerNo { get; set; }
        public string? ItemName { get; set; }
        public DateTime? LastDateofMaintenence { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? PresentState { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual ItemStor? ItemStore { get; set; }
        public virtual Trade? Trade { get; set; }
    }
}
