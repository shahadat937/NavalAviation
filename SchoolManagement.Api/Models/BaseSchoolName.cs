using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BaseSchoolName
    {
        public BaseSchoolName()
        {
            AcStatuses = new HashSet<AcStatus>();
            Acceptances = new HashSet<Acceptance>();
            AirCraftFlyings = new HashSet<AirCraftFlying>();
            AirCraftNames = new HashSet<AirCraftName>();
            ArchivingforPublications = new HashSet<ArchivingforPublication>();
            Attendences = new HashSet<Attendence>();
            CallibrationStates = new HashSet<CallibrationState>();
            DailyAirworthinessFromCategories = new HashSet<DailyAirworthinessFromCategory>();
            DailyAirworthinessFroms = new HashSet<DailyAirworthinessFrom>();
            DegitalArchieves = new HashSet<DegitalArchieve>();
            Demands = new HashSet<Demand>();
            EquipmentIssues = new HashSet<EquipmentIssue>();
            EquipmentNames = new HashSet<EquipmentName>();
            GseItemNames = new HashSet<GseItemName>();
            GseMaintenanceScheduleNames = new HashSet<GseMaintenanceScheduleName>();
            GseMaintenances = new HashSet<GseMaintenance>();
            GseScheduleWorkTypes = new HashSet<GseScheduleWorkType>();
            IssueRegisters = new HashSet<IssueRegister>();
            ItemDetails = new HashSet<ItemDetail>();
            ItemStors = new HashSet<ItemStor>();
            LifeLimitItemRunningHours = new HashSet<LifeLimitItemRunningHour>();
            MaintenanceCategories = new HashSet<MaintenanceCategory>();
            MaintenancePlannings = new HashSet<MaintenancePlanning>();
            MaintenanceSchedules = new HashSet<MaintenanceSchedule>();
            MaintenanceSubCategories = new HashSet<MaintenanceSubCategory>();
            MaintenanceTypes = new HashSet<MaintenanceType>();
            MaintenenceStates = new HashSet<MaintenenceState>();
            MeaSquadronStates = new HashSet<MeaSquadronState>();
            NameofPublications = new HashSet<NameofPublication>();
            NoticeBoards = new HashSet<NoticeBoard>();
            PreviousItemStores = new HashSet<PreviousItemStore>();
            Procurements = new HashSet<Procurement>();
            RequiredSparesForMaintenances = new HashSet<RequiredSparesForMaintenance>();
            RunningHours = new HashSet<RunningHour>();
            StockTransferNsds = new HashSet<StockTransferNsd>();
            Surveys = new HashSet<Survey>();
            ToolsIssues = new HashSet<ToolsIssue>();
            TrainingCrews = new HashSet<TrainingCrew>();
            Users = new HashSet<User>();
        }

        public int BaseSchoolNameId { get; set; }
        public string SchoolName { get; set; }
        public string ShortName { get; set; }
        public string SchoolLogo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public int? BranchLevel { get; set; }
        public int? FirstLevel { get; set; }
        public int? SecondLevel { get; set; }
        public int? ThirdLevel { get; set; }
        public int? FourthLevel { get; set; }
        public int? FifthLevel { get; set; }
        public string ServerName { get; set; }

        public virtual ICollection<AcStatus> AcStatuses { get; set; }
        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<AirCraftFlying> AirCraftFlyings { get; set; }
        public virtual ICollection<AirCraftName> AirCraftNames { get; set; }
        public virtual ICollection<ArchivingforPublication> ArchivingforPublications { get; set; }
        public virtual ICollection<Attendence> Attendences { get; set; }
        public virtual ICollection<CallibrationState> CallibrationStates { get; set; }
        public virtual ICollection<DailyAirworthinessFromCategory> DailyAirworthinessFromCategories { get; set; }
        public virtual ICollection<DailyAirworthinessFrom> DailyAirworthinessFroms { get; set; }
        public virtual ICollection<DegitalArchieve> DegitalArchieves { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<EquipmentIssue> EquipmentIssues { get; set; }
        public virtual ICollection<EquipmentName> EquipmentNames { get; set; }
        public virtual ICollection<GseItemName> GseItemNames { get; set; }
        public virtual ICollection<GseMaintenanceScheduleName> GseMaintenanceScheduleNames { get; set; }
        public virtual ICollection<GseMaintenance> GseMaintenances { get; set; }
        public virtual ICollection<GseScheduleWorkType> GseScheduleWorkTypes { get; set; }
        public virtual ICollection<IssueRegister> IssueRegisters { get; set; }
        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
        public virtual ICollection<ItemStor> ItemStors { get; set; }
        public virtual ICollection<LifeLimitItemRunningHour> LifeLimitItemRunningHours { get; set; }
        public virtual ICollection<MaintenanceCategory> MaintenanceCategories { get; set; }
        public virtual ICollection<MaintenancePlanning> MaintenancePlannings { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<MaintenanceSubCategory> MaintenanceSubCategories { get; set; }
        public virtual ICollection<MaintenanceType> MaintenanceTypes { get; set; }
        public virtual ICollection<MaintenenceState> MaintenenceStates { get; set; }
        public virtual ICollection<MeaSquadronState> MeaSquadronStates { get; set; }
        public virtual ICollection<NameofPublication> NameofPublications { get; set; }
        public virtual ICollection<NoticeBoard> NoticeBoards { get; set; }
        public virtual ICollection<PreviousItemStore> PreviousItemStores { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
        public virtual ICollection<RunningHour> RunningHours { get; set; }
        public virtual ICollection<StockTransferNsd> StockTransferNsds { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<ToolsIssue> ToolsIssues { get; set; }
        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
