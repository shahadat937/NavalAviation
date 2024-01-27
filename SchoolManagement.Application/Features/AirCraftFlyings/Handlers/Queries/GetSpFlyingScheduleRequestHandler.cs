using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Handlers.Queries
{
    public class GetSpFlyingScheduleRequestHandler : IRequestHandler<GetSpFlyingScheduleRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftFlying> _FlyingTimeByAricraftRepository;

        private readonly IMapper _mapper;

        public GetSpFlyingScheduleRequestHandler(ISchoolManagementRepository<AirCraftFlying> FlyingTimeByAricraftRepository, IMapper mapper)
        {
            _FlyingTimeByAricraftRepository = FlyingTimeByAricraftRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSpFlyingScheduleRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetFlyingSchedule] '{0}','{1}',{2}", request.DateFrom, request.DateTo, request.DepartmentId);

            DataTable dataTable = _FlyingTimeByAricraftRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
