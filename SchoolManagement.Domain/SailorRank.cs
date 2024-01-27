using System;
using System.Collections.Generic;
using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SailorRank : BaseDomainEntity
  {
        public SailorRank()
        {
            TrainingCrews = new HashSet<TrainingCrew>();
        }

        public int SailorRankId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TrainingCrew> TrainingCrews { get; set; }
    }
}
