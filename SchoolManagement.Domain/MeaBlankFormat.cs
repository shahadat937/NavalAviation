using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class MeaBlankFormat : BaseDomainEntity
    {
        public MeaBlankFormat()
        {

        }

        public int MeaBlankFormatId { get; set; }
        public string? Name { get; set; }
        public string? Doc { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
