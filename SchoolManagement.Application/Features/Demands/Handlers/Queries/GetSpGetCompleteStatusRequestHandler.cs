using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetSpGetCompleteStatusRequestHandler : IRequestHandler<GetSpGetCompleteStatusRequest, object>
    {

        private readonly ISchoolManagementRepository<Demand> _DemandRepository;

        private readonly IMapper _mapper;

        public GetSpGetCompleteStatusRequestHandler(ISchoolManagementRepository<Demand> DemandRepository, IMapper mapper)
        {
            _DemandRepository = DemandRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSpGetCompleteStatusRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetCompleteStatus] {0}",request.DepartmentId);

            DataTable dataTable = _DemandRepository.ExecWithSqlQuery(spQuery);

           
            return dataTable;
         
        }
    }
}
