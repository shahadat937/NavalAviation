using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DailyAirworthinessFrom
    {
        public int DailyAirworthinessFromId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? DailyAirworthinessFromCategoryId { get; set; }
        public string Name { get; set; }
        public int? DocType { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Doc { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual AirCraftName AirCraftName { get; set; }
        public virtual DailyAirworthinessFromCategory DailyAirworthinessFromCategory { get; set; }
        public virtual BaseSchoolName DepartmentName { get; set; }
    }
}
