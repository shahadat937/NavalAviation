using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.MaintenancePlannings.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.MaintenancePlannings.Handlers.Queries
{
    public class GetSpAcUnderMaintenanceRequestHandler : IRequestHandler<GetSpAcUnderMaintenanceRequest, object>
    {

        private readonly ISchoolManagementRepository<MaintenancePlanning> _MaintenancePlanningRepository;

        private readonly IMapper _mapper;

        public GetSpAcUnderMaintenanceRequestHandler(ISchoolManagementRepository<MaintenancePlanning> MaintenancePlanningRepository, IMapper mapper)
        {
            _MaintenancePlanningRepository = MaintenancePlanningRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSpAcUnderMaintenanceRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAcUnderMaintenance] '{0}',{1}", request.Current, request.DepartmentId);

            DataTable dataTable = _MaintenancePlanningRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
