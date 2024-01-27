using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class IssueStatus : BaseDomainEntity
    {
        public IssueStatus()
        {
            IssueRegisters = new HashSet<IssueRegister>();
        }

        public int IssueStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<IssueRegister> IssueRegisters { get; set; }
    }
}
