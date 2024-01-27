using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using System.Data;
using SchoolManagement.Application.Features.Demands.Requests.Queries;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetOpearionalAircraftNameCountRequestHandler : IRequestHandler<GetOpearionalAircraftNameCountRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftName> _airCraftNameRepository;

        private readonly IMapper _mapper;

        public GetOpearionalAircraftNameCountRequestHandler(ISchoolManagementRepository<AirCraftName> airCraftNameRepository, IMapper mapper)
        {
            _airCraftNameRepository = airCraftNameRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetOpearionalAircraftNameCountRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetOperationalAircraftNameCount] {0}", request.DepartmentId);

            DataTable dataTable = _airCraftNameRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
