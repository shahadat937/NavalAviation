using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CurrencyName
    {
        public CurrencyName()
        {
            Countries = new HashSet<Country>();
        }

        public int CurrencyNameId { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
