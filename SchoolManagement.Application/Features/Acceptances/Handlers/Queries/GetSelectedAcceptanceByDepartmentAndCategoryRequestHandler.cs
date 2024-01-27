using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetSelectedAcceptanceByDepartmentAndCategoryRequestHandler :  IRequestHandler<GetSelectedAcceptanceByDepartmentAndCategoryRequest, List<AcceptanceDto>>
    {
        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;
        private readonly IMapper _mapper;


        public GetSelectedAcceptanceByDepartmentAndCategoryRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository, IMapper mapper)
        {
            _AcceptanceRepository = AcceptanceRepository;
            _mapper = mapper;
        }

        

        public async Task<List<AcceptanceDto>> Handle(GetSelectedAcceptanceByDepartmentAndCategoryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Acceptance> Acceptances = _AcceptanceRepository.FilterWithInclude(x => x.AcceptanceId == request.AcceptanceId, "ItemDetail", "Demand");
            

            var AcceptanceDtos = _mapper.Map<List<AcceptanceDto>>(Acceptances);

            return AcceptanceDtos;
        }
    }
}
