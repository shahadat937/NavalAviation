using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetPersonalStatesByStatusSpRequestHandler : IRequestHandler<GetPersonalStatesByStatusSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository;

        private readonly IMapper _mapper;

        public GetPersonalStatesByStatusSpRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository, IMapper mapper)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetPersonalStatesByStatusSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetPersonalStateByStatus] {0}, {1}, {2}, {3}", request.DepartmentNameId, request.OfficersStatusId, request.PresentBilletId, request.EmployeeTypeId);

            DataTable dataTable = _TrainingCrewRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
