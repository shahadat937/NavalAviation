using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Handlers.Queries
{
    public class GetAirCraftFlyingSpRequestHandler : IRequestHandler<GetAirCraftFlyingSpRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftFlying> _FlyingTimeByAricraftRepository;

        private readonly IMapper _mapper;

        public GetAirCraftFlyingSpRequestHandler(ISchoolManagementRepository<AirCraftFlying> FlyingTimeByAricraftRepository, IMapper mapper)
        {
            _FlyingTimeByAricraftRepository = FlyingTimeByAricraftRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetAirCraftFlyingSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAricraftFlying] '{0}',{1}", request.Current, request.DepartmentId);

            DataTable dataTable = _FlyingTimeByAricraftRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
