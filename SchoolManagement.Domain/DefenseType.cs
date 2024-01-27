using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class DefenseType : BaseDomainEntity
    {
        public int DefenseTypeId { get; set; }
        public string DefenseTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
