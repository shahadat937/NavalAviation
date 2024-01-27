using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class StepRelation : BaseDomainEntity
    {
        public int StepRelationId { get; set; }
        public string? StepRelationType { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
    }
}
