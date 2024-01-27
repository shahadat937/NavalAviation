using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetSpTrainingCrewRequestHandler : IRequestHandler<GetSpPersonalStateRequest, object>
    {

        private readonly ISchoolManagementRepository<TrainingCrew> _TrainingCrewRepository;

        private readonly IMapper _mapper;

        public GetSpTrainingCrewRequestHandler(ISchoolManagementRepository<TrainingCrew> TrainingCrewRepository, IMapper mapper)
        {
            _TrainingCrewRepository = TrainingCrewRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSpPersonalStateRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetPersonalState] {0}", request.DepartmentId);

            DataTable dataTable = _TrainingCrewRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
