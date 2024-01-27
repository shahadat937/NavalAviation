using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingCrew
{
    public class TrainingCrewDto : ITrainingCrewDto
    {
        public int TrainingCrewId { get; set; }
        public int? CourseId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? OfficersStatusId { get; set; } 
        public int? EmployeeTypeId { get; set; }
        public int? SailorRankId { get; set; }
        public int? RankId { get; set; }
        public string? Pno { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public string? Duties { get; set; }
        public string? AviationCategory { get; set; }
        public int? PresentBilletId { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
     
        public string? Rank { get; set; }
        public string? RankRemarks { get; set; }
        public string? SailorRank { get; set; }
            //public string? Course { get; set; }
        public string? DepartmentName { get; set; }
        public string? OfficersStatus { get; set; }
    }
}
