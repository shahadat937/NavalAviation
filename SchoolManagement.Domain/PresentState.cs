using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class PresentState : BaseDomainEntity
    {
        public PresentState()
        {
            MeaSquadronStates = new HashSet<MeaSquadronState>();
        }

        public int PresentStateId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MeaSquadronState> MeaSquadronStates { get; set; }
    }
}
