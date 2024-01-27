using MediatR;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetPersonalStatesByStatusSpRequest : IRequest<object>
    {
    public int DepartmentNameId { get; set; }
    public int OfficersStatusId { get; set; }
    public int PresentBilletId { get; set; }
    public int EmployeeTypeId { get; set; }
  }
}
