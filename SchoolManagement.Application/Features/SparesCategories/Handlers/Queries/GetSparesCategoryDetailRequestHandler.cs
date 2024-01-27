using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SparesCategorys;
using SchoolManagement.Application.Features.SparesCategories.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SparesCategories.Handlers.Queries
{
    public class GetSparesCategoryDetailRequestHandler : IRequestHandler<GetSparesCategoryDetailRequest, SparesCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SparesCategory> _SparesCategoryRepository;
        public GetSparesCategoryDetailRequestHandler(ISchoolManagementRepository<SparesCategory> SparesCategoryRepository, IMapper mapper)
        {
            _SparesCategoryRepository = SparesCategoryRepository;
            _mapper = mapper;
        }
        public async Task<SparesCategoryDto> Handle(GetSparesCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var SparesCategory = await _SparesCategoryRepository.Get(request.SparesCategoryId);
            return _mapper.Map<SparesCategoryDto>(SparesCategory);
        }
    }
}
