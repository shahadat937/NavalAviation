using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class Nationality : BaseDomainEntity
    {
        public int NationalityId { get; set; }
        public string NationalityName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
