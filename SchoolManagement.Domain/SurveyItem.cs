using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class SurveyItem : BaseDomainEntity
    {
        public int SurveyItemId { get; set; }
        public int? DenoId { get; set; }
        public int? ItemStatusId { get; set; }
        public string? PartNo { get; set; }
        public string? Qty { get; set; }
        public string? SurveyNo { get; set; }
        public string? NsdSrNo { get; set; }
        public DateTime? SurveyDate { get; set; }
        public string? ItemSerNo { get; set; }
        public string? SurveyDocument { get; set; }
        public string? DemandNo { get; set; }
        public string? ReturnStore { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Deno? Deno { get; set; }
        public virtual ItemStatus? ItemStatus { get; set; }
    }
}
