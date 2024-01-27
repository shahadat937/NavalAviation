using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.TrainingCrew;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetTrainingCrewListByDepartmentNameIdSailorRequest : IRequest<List<TrainingCrewDto>>
    {
        public string Text { get; set; }
        public int DepartmentNameId { get; set; }
        public int EmployeeTypeId { get; set; }

    } 
}

