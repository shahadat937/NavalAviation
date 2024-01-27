using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.Demands
{
    public class CreateDemandDto : IDemandDto
    {
        public int DemandId { get; set; }
        public int? AuthorityId { get; set; }
        public int? TradeId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? SupplierId { get; set; }
        public int? ManufactureId { get; set; }
        public int? DenoId { get; set; }
        public int? FiscalYearId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? ItemTypeId { get; set; }
        public int? OccasionOfDemandId { get; set; }
        public int? DemandAuthorityId { get; set; }
        public int? DemandStatusId { get; set; }
        public int? DemandTypeId { get; set; }
        public int? SparesCategoryId { get; set; }
        public int? DemandDocId { get; set; }
        public string? SpecDoc { get; set; }
        public int? ConditionOfItemId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? DemandCompleteStatus { get; set; }
        public int? VerificationCompletStatus { get; set; }
        public string? DemandQty { get; set; }
        public string? DemandLetterNo { get; set; }
        public string? DemandNo { get; set; }
        public DateTime? DemandDate { get; set; }
        public string? LetterOuterNo { get; set; }
        public string? RefPrice { get; set; }
        public string? RefPoNo { get; set; }
        public string? Remarks { get; set; }
        public string? OldPrice { get; set; }
        public string? OldRefNo { get; set; }
        public string? ManufactureAddress { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public IFormFile? Doc { get; set; }
        public IFormFile? SpecDocument { get; set; } 
    }
}
