using System;
using System.Collections.Generic;
using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class EmployeeType : BaseDomainEntity
{
        public EmployeeType()
        {
            TrainingCrews = new HashSet<TrainingCrew>();
        }

        public int EmployeeTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
    }
}
