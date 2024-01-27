using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class PresentBillet : BaseDomainEntity
    {
        public PresentBillet()
        {
          TrainingCrews = new HashSet<TrainingCrew>();
        }

        public int PresentBilletId { get; set; }
        public string PresentBilletName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
  }
}
