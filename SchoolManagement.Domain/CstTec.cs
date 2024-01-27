using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class CstTec : BaseDomainEntity
    {
        public CstTec()
        {
            Procurements = new HashSet<Procurement>();
        }

        public int CstTecId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Procurement> Procurements { get; set; }

    }
}
