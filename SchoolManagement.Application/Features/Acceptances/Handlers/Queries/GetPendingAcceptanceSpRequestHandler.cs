using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetPendingAcceptanceSpRequestHandler : IRequestHandler<GetPendingAcceptanceSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Acceptance> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetPendingAcceptanceSpRequestHandler(ISchoolManagementRepository<Acceptance> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetPendingAcceptanceSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetPendingAcceptance] {0}", request.DepartmentId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
