using AutoMapper;
using SchoolManagement.Application.DTOs.BaseSchoolNames;
using SchoolManagement.Application.Features.BaseSchoolNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BaseSchoolNames.Handlers.Queries   
{
    public class GetBaseSchoolListByBranchLevelRequestHandler : IRequestHandler<GetBaseSchoolListByBranchLevelRequest, List<BaseSchoolNameDto>>
    {

        private readonly ISchoolManagementRepository<BaseSchoolName> _BaseSchoolNameRepository;

        private readonly IMapper _mapper;

        public GetBaseSchoolListByBranchLevelRequestHandler(ISchoolManagementRepository<BaseSchoolName> BaseSchoolNameRepository, IMapper mapper)
        {
            _BaseSchoolNameRepository = BaseSchoolNameRepository;
            _mapper = mapper;
        }

        public async Task<List<BaseSchoolNameDto>> Handle(GetBaseSchoolListByBranchLevelRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BaseSchoolName> BaseSchoolNames = _BaseSchoolNameRepository.FilterWithInclude(x => x.BranchLevel == 4).OrderBy(x => x.BaseSchoolNameId);

            var BaseSchoolNameDtos = _mapper.Map<List<BaseSchoolNameDto>>(BaseSchoolNames);

            return BaseSchoolNameDtos;
        }
    }
}
