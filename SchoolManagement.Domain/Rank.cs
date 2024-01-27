using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Rank : BaseDomainEntity
    {
        public Rank()
        {
            TrainingCrews = new HashSet<TrainingCrew>();
        }

        public int RankId { get; set; }
        public string? Name { get; set; } 
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
    }
}
