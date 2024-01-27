using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class ItemStatus : BaseDomainEntity
    {
        public ItemStatus()
        {
            
            SurveyItems = new HashSet<SurveyItem>();
        }

        public int ItemStatusId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }

       
        public virtual ICollection<SurveyItem> SurveyItems { get; set; }
    }
}
