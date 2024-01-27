using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DailyAirworthinessFromCategory
    {
        public DailyAirworthinessFromCategory()
        {
            DailyAirworthinessFroms = new HashSet<DailyAirworthinessFrom>();
        }

        public int DailyAirworthinessFromCategoryId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ICollection<DailyAirworthinessFrom> DailyAirworthinessFroms { get; set; }
    }
}
