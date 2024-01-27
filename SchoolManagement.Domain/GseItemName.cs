using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class GseItemName : BaseDomainEntity
    {
        public GseItemName()
        {
            GseMaintenances = new HashSet<GseMaintenance>();
        }

        public int GseItemNameId { get; set; }
        public string? ItemName { get; set; }
        public string? Remarks { get; set; }
        public int? DepartmentNameId { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ICollection<GseMaintenance> GseMaintenances { get; set; }
    }
}
