using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class OfficersStatus : BaseDomainEntity
    {
        public OfficersStatus()
        {
            TrainingCrews = new HashSet<TrainingCrew>();
        }

        public int OfficersStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
    }
}
