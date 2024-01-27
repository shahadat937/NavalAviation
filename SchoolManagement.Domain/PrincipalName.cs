using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class PrincipalName : BaseDomainEntity
    {
        public PrincipalName()
        {
            Acceptances = new HashSet<Acceptance>();
            Procurements = new HashSet<Procurement>();
        }

        public int PrincipalNameId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Acceptance> Acceptances { get; set; }
        public virtual ICollection<Procurement> Procurements { get; set; }
    }
}
