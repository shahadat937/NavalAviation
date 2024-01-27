using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class MeaWorkShop : BaseDomainEntity
    {
        public MeaWorkShop()
        {
            MeaSquadronStates = new HashSet<MeaSquadronState>();

        }

        public int MeaWorkShopId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? Position { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<MeaSquadronState> MeaSquadronStates { get; set; }

     }
}
