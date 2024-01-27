using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TrainingCrews.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TrainingCrews.Handlers.Queries
{
    public class GetTrainingCrewSpRequestHandler : IRequestHandler<GetTrainingCrewSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TrainingCrew> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetTrainingCrewSpRequestHandler(ISchoolManagementRepository<TrainingCrew> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTrainingCrewSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetTrainingCrew] {0}", request.DepartmentId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
