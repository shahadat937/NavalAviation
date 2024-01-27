using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries
{
    public class GetMaintenanceScheduleRecordListByParamsRequestHandler : IRequestHandler<GetMaintenanceScheduleRecordListByParamsRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftFlying> _FlyingTimeByAricraftRepository;

        private readonly IMapper _mapper;

        public GetMaintenanceScheduleRecordListByParamsRequestHandler(ISchoolManagementRepository<AirCraftFlying> FlyingTimeByAricraftRepository, IMapper mapper)
        {
            _FlyingTimeByAricraftRepository = FlyingTimeByAricraftRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetMaintenanceScheduleRecordListByParamsRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetMaintenanceRecords] {0},{1},{2},{3},{4}", request.DepartmentNameId, request.AirCraftNameId, request.MaintenanceTypeId, request.MaintenanceCategoryId, request.MaintenanceSubCategoryId);

            DataTable dataTable = _FlyingTimeByAricraftRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
