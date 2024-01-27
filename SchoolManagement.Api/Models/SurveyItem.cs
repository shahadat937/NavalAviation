using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SurveyItem
    {
        public int SurveyItemId { get; set; }
        public int? DenoId { get; set; }
        public int? ItemStatusId { get; set; }
        public int? ItemDetailId { get; set; }
        public string Qty { get; set; }
        public string SurveyNo { get; set; }
        public string NsdSrNo { get; set; }
        public DateTime? SurveyDate { get; set; }
        public string ItemSerNo { get; set; }
        public string SurveyDocument { get; set; }
        public string DemandNo { get; set; }
        public string ReturnStore { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Deno Deno { get; set; }
        public virtual ItemDetail ItemDetail { get; set; }
        public virtual ItemStatus ItemStatus { get; set; }
    }
}
