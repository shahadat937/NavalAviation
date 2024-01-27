using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Handlers.Queries
{
    public class GetAcceptanceListByPattNoSpRequestHandler : IRequestHandler<GetAcceptanceListByPattNoSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;

        private readonly IMapper _mapper;

        public GetAcceptanceListByPattNoSpRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository, IMapper mapper)
        {
            _AcceptanceRepository = AcceptanceRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetAcceptanceListByPattNoSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAcceptanceListByPattNo] {0}", request.ItemDetailId);

            DataTable dataTable = _AcceptanceRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
