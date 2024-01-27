namespace SchoolManagement.Application.DTOs.CallibrationState
{
    public class CallibrationStateDto : ICallibrationStateDto
    {
        public int CallibrationStateId { get; set; }
        public int? ItemDetailId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? TradeId { get; set; }
        public string? SerNo { get; set; }
        public string? ItemName { get; set; }
        public DateTime? LastDateofCalibrated { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? PresentState { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? Trade { get; set; }
        public string? ItemDetail { get; set; }
    }
}
