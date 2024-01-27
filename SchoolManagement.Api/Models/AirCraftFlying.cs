using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AirCraftFlying
    {
        public int AirCraftFlyingId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public DateTime? Date { get; set; }
        public string TypeOfAc { get; set; }
        public string AcNo { get; set; }
        public string Crew { get; set; }
        public string CallSign { get; set; }
        public string Mon { get; set; }
        public string StartUp { get; set; }
        public string Dup { get; set; }
        public string Endurance { get; set; }
        public string Fuel { get; set; }
        public string OpaOff { get; set; }
        public string Pdf { get; set; }
        public string StartupPlanned { get; set; }
        public string LandingTimePlanned { get; set; }
        public string Duration { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? StartUpStatus { get; set; }
        public string StartUpDelay { get; set; }

        public virtual AirCraftName AirCraftName { get; set; }
        public virtual BaseSchoolName DepartmentName { get; set; }
    }
}
