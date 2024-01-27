using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetMaintenanceSubCategoryDetailRequestHandler : IRequestHandler<GetMaintenanceSubCategoryDetailRequest, MaintenanceSubCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;
        public GetMaintenanceSubCategoryDetailRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository, IMapper mapper)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;
            _mapper = mapper;
        }
        public async Task<MaintenanceSubCategoryDto> Handle(GetMaintenanceSubCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var MaintenanceSubCategory = await _MaintenanceSubCategoryRepository.Get(request.MaintenanceSubCategoryId);
            return _mapper.Map<MaintenanceSubCategoryDto>(MaintenanceSubCategory);
        }
    }
}
