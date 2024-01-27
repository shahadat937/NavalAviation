using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Queries
{
    public class GetPendingProcurementSpRequestHandler : IRequestHandler<GetPendingProcurementSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Procurement> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetPendingProcurementSpRequestHandler(ISchoolManagementRepository<Procurement> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetPendingProcurementSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetPendingProcurement] {0}", request.DepartmentId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
