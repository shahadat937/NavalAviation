using SchoolManagement.Domain.Common;
using static System.Formats.Asn1.AsnWriter;

namespace SchoolManagement.Domain
{
    public class TestEquipmentDetail : BaseDomainEntity
    {
        public int TestEquipmentDetailId { get; set; }
        public int? ShopId { get; set; }
        public string? EquipmentName { get; set; }
        public string? PattNo { get; set; }
        public string? Deno { get; set; }
        public int? Qty { get; set; }
        public string? ShelfLife { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Shop? Shop { get; set; }
    }
}
