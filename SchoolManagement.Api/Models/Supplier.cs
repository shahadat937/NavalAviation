using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Demands = new HashSet<Demand>();
            ProcurementSupplierAs = new HashSet<Procurement>();
            ProcurementSupplierMs = new HashSet<Procurement>();
            ProcurementSuppliers = new HashSet<Procurement>();
        }

        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Fax { get; set; }
        public bool? EnlistedType { get; set; }
        public string ContractPersonName { get; set; }
        public string ContractPersonNumber { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<Procurement> ProcurementSupplierAs { get; set; }
        public virtual ICollection<Procurement> ProcurementSupplierMs { get; set; }
        public virtual ICollection<Procurement> ProcurementSuppliers { get; set; }
    }
}
