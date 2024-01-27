using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using System.Data;
using SchoolManagement.Application.Features.Demands.Requests.Queries;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetNonOpearionalAircraftNameCountRequestHandler : IRequestHandler<GetNonOpearionalAircraftNameCountRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftName> _airCraftNameRepository;

        private readonly IMapper _mapper;

        public GetNonOpearionalAircraftNameCountRequestHandler(ISchoolManagementRepository<AirCraftName> airCraftNameRepository, IMapper mapper)
        {
            _airCraftNameRepository = airCraftNameRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNonOpearionalAircraftNameCountRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetNonOperationalAircraftCount] {0}", request.DepartmentId);

            DataTable dataTable = _airCraftNameRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
