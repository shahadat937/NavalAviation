using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class DailyAirworthinessFromCategory : BaseDomainEntity
    {
        public DailyAirworthinessFromCategory()
        {
            DailyAirworthinessFroms = new HashSet<DailyAirworthinessFrom>();

        }

        public int DailyAirworthinessFromCategoryId { get; set; }
        public int? DepartmentNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? DepartmentName { get; set; }
        public virtual ICollection<DailyAirworthinessFrom> DailyAirworthinessFroms { get; set; }
    }
}
