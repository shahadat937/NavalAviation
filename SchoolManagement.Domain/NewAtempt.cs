using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class NewAtempt : BaseDomainEntity
    {
        public int NewAtemptId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
