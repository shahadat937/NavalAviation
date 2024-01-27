using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetSpACStatusTotalCountForOperationalOrUnderMaintRequestHandler : IRequestHandler<GetSpACStatusTotalCountForOperationalOrUnderMaintRequest, object>
    {

        private readonly ISchoolManagementRepository<AirCraftName> _AirCraftNameRepository;

        private readonly IMapper _mapper;

        public GetSpACStatusTotalCountForOperationalOrUnderMaintRequestHandler(ISchoolManagementRepository<AirCraftName> AirCraftNameRepository, IMapper mapper)
        {
            _AirCraftNameRepository = AirCraftNameRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSpACStatusTotalCountForOperationalOrUnderMaintRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetACStatusCountForMaint]");

            DataTable dataTable = _AirCraftNameRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
