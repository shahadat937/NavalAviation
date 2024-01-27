using MediatR;
using SchoolManagement.Application.DTOs.TrainingCrew;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetTrainingCrewPresentListByDepartmentNameIdRequest : IRequest<List<TrainingCrewDto>>
    {
        public int DepartmentNameId { get; set; }
        public int OfficersStatusId { get; set; }
    }  
}
 
