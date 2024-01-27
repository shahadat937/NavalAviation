using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Course : BaseDomainEntity
    {
        public Course()
        {
            TrainingCrews = new HashSet<TrainingCrew>();
        }

        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
    }
}
