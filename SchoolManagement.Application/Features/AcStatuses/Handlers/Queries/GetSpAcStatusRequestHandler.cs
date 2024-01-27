using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.AcStatuses.Handlers.Queries
{
    public class GetSpAcStatusRequestHandler : IRequestHandler<GetSpAcStatusRequest, object>
    {

        private readonly ISchoolManagementRepository<AcStatus> _AcStatusRepository;

        private readonly IMapper _mapper;

        public GetSpAcStatusRequestHandler(ISchoolManagementRepository<AcStatus> AcStatusRepository, IMapper mapper)
        {
            _AcStatusRepository = AcStatusRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSpAcStatusRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAircraftStatus] '{0}',{1}", request.Current, request.DepartmentId);

            DataTable dataTable = _AcStatusRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
