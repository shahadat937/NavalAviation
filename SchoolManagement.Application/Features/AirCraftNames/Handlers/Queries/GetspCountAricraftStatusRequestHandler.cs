using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetspCountAricraftStatusRequestHandler : IRequestHandler<GetspCountAricraftStatusRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftName> _AirCraftNameRepository;

        private readonly IMapper _mapper;

        public GetspCountAricraftStatusRequestHandler(ISchoolManagementRepository<AirCraftName> AirCraftNameRepository, IMapper mapper)
        {
            _AirCraftNameRepository = AirCraftNameRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetspCountAricraftStatusRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetCountAricraftStatus] '{0}',{1}", request.Current, request.DepartmentId);

            DataTable dataTable = _AirCraftNameRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
