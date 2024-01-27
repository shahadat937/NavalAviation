using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class DailyAirworthinessFrom : BaseDomainEntity
    {
        public DailyAirworthinessFrom()
        {
           
           
        }

        public int DailyAirworthinessFromId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? AirCraftNameId { get; set; }
        public int? DailyAirworthinessFromCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Doc { get; set; }
        public int? DocType { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual DailyAirworthinessFromCategory? DailyAirworthinessFromCategory { get; set; }
        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual AirCraftName? AirCraftName { get; set; }
    }
}
