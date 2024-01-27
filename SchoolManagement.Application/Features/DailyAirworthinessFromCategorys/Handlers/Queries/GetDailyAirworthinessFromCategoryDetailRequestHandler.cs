using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DailyAirworthinessFromCategory;
using SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Requests.Queries;

namespace SchoolManagement.Application.Features.DailyAirworthinessFromCategorys.Handlers.Queries
{
    public class GetDailyAirworthinessFromCategoryDetailRequestHandler : IRequestHandler<GetDailyAirworthinessFromCategoryDetailRequest, DailyAirworthinessFromCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFromCategory> _DailyAirworthinessFromCategoryRepository;
        public GetDailyAirworthinessFromCategoryDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DailyAirworthinessFromCategory> DailyAirworthinessFromCategoryRepository, IMapper mapper)
        {
            _DailyAirworthinessFromCategoryRepository = DailyAirworthinessFromCategoryRepository;
            _mapper = mapper;
        }
        public async Task<DailyAirworthinessFromCategoryDto> Handle(GetDailyAirworthinessFromCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var DailyAirworthinessFromCategory = await _DailyAirworthinessFromCategoryRepository.Get(request.DailyAirworthinessFromCategoryId);
            return _mapper.Map<DailyAirworthinessFromCategoryDto>(DailyAirworthinessFromCategory);
        }
    }
}
