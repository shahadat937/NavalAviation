using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CountryGroup
    {
        public CountryGroup()
        {
            Countries = new HashSet<Country>();
        }

        public int CountryGroupId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
