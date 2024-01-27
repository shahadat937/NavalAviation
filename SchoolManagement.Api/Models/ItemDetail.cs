using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ItemDetail
    {
        public ItemDetail()
        {
            Acceptances = new HashSet<Acceptance>();
            ArchivingforPublications = new HashSet<ArchivingforPublication>();
            CallibrationStates = new HashSet<CallibrationState>();
            Demands = new HashSet<Demand>();
            EquipmentIssues = new HashSet<EquipmentIssue>();
            IssueRegisters = new HashSet<IssueRegister>();
            ItemStors = new HashSet<ItemStor>();
            LifeLimitItemRunningHours = new HashSet<LifeLimitItemRunningHour>();
            MaintenenceStates = new HashSet<MaintenenceState>();
            MeaSquadronStates = new HashSet<MeaSquadronState>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
            Procurements = new HashSet<Procurement>();
            RequiredSparesForMaintenances = new HashSet<RequiredSparesForMaintenance>();
            StockTransferNsds = new HashSet<StockTransferNsd>();
            SurveyItems = new HashSet<SurveyItem>();
            Surveys = new HashSet<Survey>();
            ToolsIssues = new HashSet<ToolsIssue>();
        }

        public int ItemDetailId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? TradeId { get; set; }
        public string NameOfItem { get; set; }
        public string PartNo { get; set; }
        public string AlternatiovePrartNo { get; set; }
        public string SerialNo { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int? EquipmentNameId { get; set; }
        public string ImcNumber { get; set; }
        public int? ItemCategoryTypeId { get; set; }
        public int? ItemTypeId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string MinimumStock { get; set; }
        public int? CalibrationState { get; set; }
        public int? MaintananceState { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ItemCategoryType ItemCategoryType { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual SparesCategory SparesCategory { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<ArchivingforPublication> ArchivingforPublications { get; set; }
        public virtual ICollection<CallibrationState> CallibrationStates { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<EquipmentIssue> EquipmentIssues { get; set; }
        public virtual ICollection<IssueRegister> IssueRegisters { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<LifeLimitItemRunningHour> LifeLimitItemRunningHours { get; set; }
        public virtual ICollection<MaintenenceState> MaintenenceStates { get; set; }
        public virtual ICollection<MeaSquadronState> MeaSquadronStates { get; set; }
        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
        public virtual ICollection<StockTransferNsd> StockTransferNsds { get; set; }
        public virtual ICollection<SurveyItem> SurveyItems { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<ToolsIssue> ToolsIssues { get; set; }
    }
}
