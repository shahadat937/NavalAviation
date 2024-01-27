using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ArchivingforPublication : BaseDomainEntity
    {
        public ArchivingforPublication()
        {
            
        }

        public int ArchivingforPublicationId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? NameofPublicationId { get; set; }
        public string? DocumentName { get; set; }
        public DateTime? Date { get; set; }
        public string? DocUpload { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ItemDetail? ItemDetail { get; set; }
        public virtual AirCraftName? AirCraftName { get; set; }
        public virtual NameofPublication? NameofPublication { get; set; }


     }
}
