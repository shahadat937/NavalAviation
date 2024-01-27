using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ShelfLifeCategory;
using SchoolManagement.Application.Features.ShelfLifeCategorys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ShelfLifeCategorys.Handlers.Queries
{
    public class GetShelfLifeCategoryDetailRequestHandler : IRequestHandler<GetShelfLifeCategoryDetailRequest, ShelfLifeCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ShelfLifeCategory> _ShelfLifeCategoryRepository;
        public GetShelfLifeCategoryDetailRequestHandler(ISchoolManagementRepository<ShelfLifeCategory> ShelfLifeCategoryRepository, IMapper mapper)
        {
            _ShelfLifeCategoryRepository = ShelfLifeCategoryRepository;
            _mapper = mapper;
        }
        public async Task<ShelfLifeCategoryDto> Handle(GetShelfLifeCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var ShelfLifeCategory = await _ShelfLifeCategoryRepository.Get(request.ShelfLifeCategoryId);
            return _mapper.Map<ShelfLifeCategoryDto>(ShelfLifeCategory);
        }
    }
}
