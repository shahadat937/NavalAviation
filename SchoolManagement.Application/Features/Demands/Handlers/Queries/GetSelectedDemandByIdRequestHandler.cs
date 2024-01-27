using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetSelectedDemandByIdRequestHandler :  IRequestHandler<GetSelectedDemandByIdRequest, List<DemandDto>>
    {
        private readonly ISchoolManagementRepository<Demand> _DemandRepository;
        private readonly IMapper _mapper;


        public GetSelectedDemandByIdRequestHandler(ISchoolManagementRepository<Demand> DemandRepository, IMapper mapper)
        {
            _DemandRepository = DemandRepository;
            _mapper = mapper;
        }

        

        public async Task<List<DemandDto>> Handle(GetSelectedDemandByIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Demand> Demands = _DemandRepository.FilterWithInclude(x => x.DemandId == request.DemandId, "ItemDetail", "Authority", "Deno", "FiscalYear", "Manufacture", "ConditionOfItem", "OccasionOfDemand");
            

            var DemandDtos = _mapper.Map<List<DemandDto>>(Demands);

            return DemandDtos;
        }
    }
}
