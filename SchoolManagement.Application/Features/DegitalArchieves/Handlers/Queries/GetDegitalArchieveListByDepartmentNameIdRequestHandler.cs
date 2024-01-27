using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries;

namespace SchoolManagement.Application.Features.DegitalArchieves.Handlers.Queries
{
    public class GetDegitalArchieveListByDepartmentNameIdRequestHandler : IRequestHandler<GetDegitalArchieveListByDepartmentNameIdRequest, List<DegitalArchieveDto>>
    {
        private readonly ISchoolManagementRepository<DegitalArchieve> _DegitalArchieveRepository;

        private readonly IMapper _mapper;
        public GetDegitalArchieveListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<DegitalArchieve> DegitalArchieveRepository, IMapper mapper)
        {
            _DegitalArchieveRepository = DegitalArchieveRepository;
            _mapper = mapper;
        }

        public async Task<List<DegitalArchieveDto>> Handle(GetDegitalArchieveListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DegitalArchieve> DegitalArchieves = _DegitalArchieveRepository.FilterWithInclude(x => x.DepartmentNameId == (request.DepartmentNameId == 0 ? x.DepartmentNameId : request.DepartmentNameId) , "DepartmentName", "AirCraftName", "DegitalArchieveDocType");
            var totalCount = DegitalArchieves.Count();
            DegitalArchieves = DegitalArchieves.OrderByDescending(x => x.DegitalArchieveId);
            var DegitalArchieveDtos = _mapper.Map<List<DegitalArchieveDto>>(DegitalArchieves);

            return DegitalArchieveDtos;
        }

    }
}
