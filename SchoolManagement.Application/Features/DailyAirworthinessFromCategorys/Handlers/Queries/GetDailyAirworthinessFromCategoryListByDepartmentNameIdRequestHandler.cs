using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Handlers.Queries
{
    public class GetDailyAirworthinessFromCategoryListByDepartmentNameIdRequestHandler : IRequestHandler<GetDailyAirworthinessFromCategoryListByDepartmentNameIdRequest, List<DailyAirworthinessFromCategoryDto>>
    {
        private readonly ISchoolManagementRepository<DailyAirworthinessFromCategory> _DailyAirworthinessFromCategoryRepository;

        private readonly IMapper _mapper;
        public GetDailyAirworthinessFromCategoryListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<DailyAirworthinessFromCategory> DailyAirworthinessFromCategoryRepository, IMapper mapper)
        {
            _DailyAirworthinessFromCategoryRepository = DailyAirworthinessFromCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<DailyAirworthinessFromCategoryDto>> Handle(GetDailyAirworthinessFromCategoryListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DailyAirworthinessFromCategory> DailyAirworthinessFromCategorys = _DailyAirworthinessFromCategoryRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId , "DepartmentName");
            var totalCount = DailyAirworthinessFromCategorys.Count();
            DailyAirworthinessFromCategorys = DailyAirworthinessFromCategorys.OrderByDescending(x => x.DailyAirworthinessFromCategoryId);
            var DailyAirworthinessFromCategoryDtos = _mapper.Map<List<DailyAirworthinessFromCategoryDto>>(DailyAirworthinessFromCategorys);

            return DailyAirworthinessFromCategoryDtos;
        }

    }
}
