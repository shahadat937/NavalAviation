using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AirCraftName
    {
        public AirCraftName()
        {
            AcStatuses = new HashSet<AcStatus>();
            AirCraftFlyings = new HashSet<AirCraftFlying>();
            ArchivingforPublications = new HashSet<ArchivingforPublication>();
            DailyAirworthinessFroms = new HashSet<DailyAirworthinessFrom>();
            DegitalArchieves = new HashSet<DegitalArchieve>();
            MaintenancePlannings = new HashSet<MaintenancePlanning>();
            MaintenanceSchedules = new HashSet<MaintenanceSchedule>();
            RequiredSparesForMaintenances = new HashSet<RequiredSparesForMaintenance>();
            RunningHours = new HashSet<RunningHour>();
        }

        public int AirCraftNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string OverallLength { get; set; }
        public string WingSpan { get; set; }
        public string Height { get; set; }
        public string MaxRange { get; set; }
        public string Endurance { get; set; }
        public string MaxTakeoffAndLandingWt { get; set; }
        public string BasicOperatingWt { get; set; }
        public string CruisingSpeed { get; set; }
        public string FuelCapacity { get; set; }
        public string Crew { get; set; }
        public string MadeBy { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerMobile { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public int? AircraftStatus { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? MaintenenceState { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ICollection<AcStatus> AcStatuses { get; set; }
        public virtual ICollection<AirCraftFlying> AirCraftFlyings { get; set; }
        public virtual ICollection<ArchivingforPublication> ArchivingforPublications { get; set; }
        public virtual ICollection<DailyAirworthinessFrom> DailyAirworthinessFroms { get; set; }
        public virtual ICollection<DegitalArchieve> DegitalArchieves { get; set; }
        public virtual ICollection<MaintenancePlanning> MaintenancePlannings { get; set; }
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<RequiredSparesForMaintenance> RequiredSparesForMaintenances { get; set; }
        public virtual ICollection<RunningHour> RunningHours { get; set; }
    }
}
