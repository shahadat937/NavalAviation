using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetTrainingCrewListByDepartmentNameIdRequest : IRequest<List<TrainingCrewDto>>
    {
        public string Text { get; set; }
        public int DepartmentNameId { get; set; }
        public int EmployeeTypeId { get; set; }

    } 
}

