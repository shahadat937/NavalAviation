using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Supplier : BaseDomainEntity
    {
        public Supplier()
        {
            Procurements = new HashSet<Procurement>();
            Demands = new HashSet<Demand>();
        }
        public int SupplierId { get; set; }
        public string? CompanyName { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Fax { get; set; }
        public bool? EnlistedType { get; set; }
        public string? ContractPersonName { get; set; }
        public string? ContractPersonNumber { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Procurement> Procurements { get; set; }
        public virtual ICollection<Demand> Demands { get; set; }
    }
}
