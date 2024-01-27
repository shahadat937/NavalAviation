using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class CourseType : BaseDomainEntity
    {
        public int CourseTypeId { get; set; }
        public string CourseTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
