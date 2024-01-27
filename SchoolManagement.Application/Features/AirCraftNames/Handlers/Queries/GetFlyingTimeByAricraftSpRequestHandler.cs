using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetFlyingTimeByAricraftSpRequestHandler : IRequestHandler<GetFlyingTimeByAricraftSpRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftName> _FlyingTimeByAricraftRepository;

        private readonly IMapper _mapper;

        public GetFlyingTimeByAricraftSpRequestHandler(ISchoolManagementRepository<AirCraftName> FlyingTimeByAricraftRepository, IMapper mapper)
        {
            _FlyingTimeByAricraftRepository = FlyingTimeByAricraftRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetFlyingTimeByAricraftSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetFlyingTimeByAricraft] {0}", request.DepartmentId);

            DataTable dataTable = _FlyingTimeByAricraftRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
