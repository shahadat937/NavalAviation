namespace SchoolManagement.Application.DTOs.MaintenenceState
{
    public class CreateMaintenenceStateDto : IMaintenenceStateDto
    {
      public int MaintenenceStateId { get; set; }
      public int? ItemDetailId { get; set; }
      public int? ItemStoreId { get; set; }
      public int? DepartmentNameId { get; set; }
      public int? TradeId { get; set; }
      public string? SerNo { get; set; } 
      public string? ItemName { get; set; }
      public DateTime? LastDateofMaintenence { get; set; }
      public DateTime? NextDueDate { get; set; }

      public DateTime? CompletedDate { get; set; }
      //public DateTime? LastDateofMaintenence { get; set; } 
      public string? PresentState { get; set; }
      public string? Remarks { get; set; }
      public int? MenuPosition { get; set; }
      public bool IsActive { get; set; }
  }
}
