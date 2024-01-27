using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Demand
    {
        public Demand()
        {
            Acceptances = new HashSet<Acceptance>();
            ItemStors = new HashSet<ItemStor>();
            Procurements = new HashSet<Procurement>();
        }

        public int DemandId { get; set; }
        public int? AuthorityId { get; set; }
        public int? TradeId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? SupplierId { get; set; }
        public int? ManufactureId { get; set; }
        public int? DenoId { get; set; }
        public int? FiscalYearId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? ItemTypeId { get; set; }
        public int? OccasionOfDemandId { get; set; }
        public int? DemandAuthorityId { get; set; }
        public int? DemandStatusId { get; set; }
        public int? DemandTypeId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? DemandDocId { get; set; }
        public int? ConditionOfItemId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? DemandCompleteStatus { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string DemandQty { get; set; }
        public string DemandLetterNo { get; set; }
        public string SpecDoc { get; set; }
        public string DemandNo { get; set; }
        public DateTime? DemandDate { get; set; }
        public string LetterOuterNo { get; set; }
        public string RefPrice { get; set; }
        public string RefPoNo { get; set; }
        public string Remarks { get; set; }
        public string OldPrice { get; set; }
        public string OldRefNo { get; set; }
        public string ManufactureAddress { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Authority Authority { get; set; }
        public virtual ConditionOfItem ConditionOfItem { get; set; }
        public virtual DemandAuthority DemandAuthority { get; set; }
        public virtual DemandDoc DemandDoc { get; set; }
        public virtual DemandStatus DemandStatus { get; set; }
        public virtual DemandType DemandType { get; set; }
        public virtual Deno Deno { get; set; }
        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual FiscalYear FiscalYear { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemDetail ItemDetail { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual Manufacture Manufacture { get; set; }
        public virtual OccasionOfDemand OccasionOfDemand { get; set; }
        public virtual SparesCategory SparesCategory { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
    }
}
