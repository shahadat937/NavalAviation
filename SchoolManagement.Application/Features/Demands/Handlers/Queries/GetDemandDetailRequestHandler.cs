using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetDemandDetailRequestHandler : IRequestHandler<GetDemandDetailRequest, DemandDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Demand> _DemandRepository;
        public GetDemandDetailRequestHandler(ISchoolManagementRepository<Demand> DemandRepository, IMapper mapper)
        {
            _DemandRepository = DemandRepository;
            _mapper = mapper;
        }
        public async Task<DemandDto> Handle(GetDemandDetailRequest request, CancellationToken cancellationToken)
        {
            //var Demand = await _DemandRepository.Get(request.DemandId);
            var Demand = _DemandRepository.FinedOneInclude(x => x.DemandId == request.DemandId, "DepartmentName", "Deno", "ItemDetail", "ConditionOfItem", "DemandType", "OccasionOfDemand", "FiscalYear", "Authority", "Trade", "ItemCategory", "DemandStatus", "Manufacture");
            return _mapper.Map<DemandDto>(Demand);
        }
    }
}
