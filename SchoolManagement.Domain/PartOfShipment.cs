using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class PartOfShipment : BaseDomainEntity
    {
        public PartOfShipment()
        {
            Procurements = new HashSet<Procurement>();
        }

        public int PartOfShipmentId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Procurement> Procurements { get; set; }
    }
}
