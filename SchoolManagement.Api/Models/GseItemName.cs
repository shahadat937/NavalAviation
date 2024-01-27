using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class GseItemName
    {
        public GseItemName()
        {
            GseMaintenances = new HashSet<GseMaintenance>();
        }

        public int GseItemNameId { get; set; }
        public string ItemName { get; set; }
        public string Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName DepartmentName { get; set; }
        public virtual ICollection<GseMaintenance> GseMaintenances { get; set; }
    }
}
