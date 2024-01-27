using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Queries
{
    public class GetPresentStockForMaintenanceSpRequestHandler : IRequestHandler<GetPresentStockForMaintenanceSpRequest, object>
    {

        private readonly ISchoolManagementRepository<RequiredSparesForMaintenance> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetPresentStockForMaintenanceSpRequestHandler(ISchoolManagementRepository<RequiredSparesForMaintenance> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetPresentStockForMaintenanceSpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetPresentStockforMaintenance] {0}, {1}, {2}, {3}, {4}", request.DepartmentId, request.SparesCategoryId, request.MaintenanceTypeId, request.MaintenanceCategoryId, request.MaintenanceSubCategoryId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
