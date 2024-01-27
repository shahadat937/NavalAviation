using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.RequiredSparesForMaintenances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.RequiredSparesForMaintenances.Handlers.Queries
{
    public class GetNsdPresentStockForMaintenanceSpRequestHandler : IRequestHandler<GetNsdPresentStockForMaintenanceSpRequest, object>
    {

        private readonly ISchoolManagementRepository<RequiredSparesForMaintenance> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetNsdPresentStockForMaintenanceSpRequestHandler(ISchoolManagementRepository<RequiredSparesForMaintenance> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNsdPresentStockForMaintenanceSpRequest request, CancellationToken cancellationToken)
        {
            // object obj = new object();
            var spQuery = String.Format("exec [spGetStorePresentStockDetails] {0},{1}", request.ItemDetailId,request.ToolsLocationId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;

        }
    }
}
