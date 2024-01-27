using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class EquipmentName : BaseDomainEntity
    {
        public EquipmentName()
        {
            //ItemDetails = new HashSet<ItemDetail>();
            
        }

        public int EquipmentNameId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? SparesCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual SparesCategory? SparesCategory { get; set; }
        //public virtual ICollection<ItemDetail> ItemDetails { get; set; }
        
    }
}
