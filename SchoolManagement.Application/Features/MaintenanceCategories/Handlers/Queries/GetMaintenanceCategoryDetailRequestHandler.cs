using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Application.Features.MaintenanceCategories.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceCategories.Handlers.Queries
{
    public class GetMaintenanceCategoryDetailRequestHandler : IRequestHandler<GetMaintenanceCategoryDetailRequest, MaintenanceCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<MaintenanceCategory> _MaintenanceCategoryRepository;
        public GetMaintenanceCategoryDetailRequestHandler(ISchoolManagementRepository<MaintenanceCategory> MaintenanceCategoryRepository, IMapper mapper)
        {
            _MaintenanceCategoryRepository = MaintenanceCategoryRepository;
            _mapper = mapper;
        }
        public async Task<MaintenanceCategoryDto> Handle(GetMaintenanceCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var MaintenanceCategory = await _MaintenanceCategoryRepository.Get(request.MaintenanceCategoryId);
            return _mapper.Map<MaintenanceCategoryDto>(MaintenanceCategory);
        }
    }
}
