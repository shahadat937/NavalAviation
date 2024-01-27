using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.AirCraftName;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetAirCraftNameListByDepartmentNameIdRequestHandler : IRequestHandler<GetAirCraftNameListByDepartmentNameIdRequest, List<AirCraftNameDto>>
    {
        private readonly ISchoolManagementRepository<AirCraftName> _AirCraftNameRepository;

        private readonly IMapper _mapper;
        public GetAirCraftNameListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<AirCraftName> AirCraftNameRepository, IMapper mapper)
        {
            _AirCraftNameRepository = AirCraftNameRepository;
            _mapper = mapper;
        }

        public async Task<List<AirCraftNameDto>> Handle(GetAirCraftNameListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<AirCraftName> AirCraftNames = _AirCraftNameRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId , "DepartmentName");
            var totalCount = AirCraftNames.Count();
            AirCraftNames = AirCraftNames.OrderByDescending(x => x.AirCraftNameId);
            var AirCraftNameDtos = _mapper.Map<List<AirCraftNameDto>>(AirCraftNames);

            return AirCraftNameDtos;
        }

    }
}
