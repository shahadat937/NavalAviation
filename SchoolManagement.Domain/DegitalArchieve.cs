using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DegitalArchieve : BaseDomainEntity
    {
        public int DegitalArchieveId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? DegitalArchieveDocTypeId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfLastRev { get; set; }
        public string? Doc { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual AirCraftName? AirCraftName { get; set; }
        public virtual DegitalArchieveDocType? DegitalArchieveDocType { get; set; }
     }
}
