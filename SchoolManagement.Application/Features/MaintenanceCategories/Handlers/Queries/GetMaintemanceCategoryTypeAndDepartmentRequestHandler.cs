using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenanceCategory;
using SchoolManagement.Application.Features.MaintenanceCategoriess.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintenanceCategorys.Handlers.Queries
{
    public class GetMaintemanceCategoryTypeAndDepartmentRequestHandler : IRequestHandler<GetMaintemanceCategoryTypeAndDepartmentRequest, List<MaintenanceCategoryDto>>
    {
        private readonly ISchoolManagementRepository<MaintenanceCategory> _MaintenanceCategoryRepository;

        private readonly IMapper _mapper;
        public GetMaintemanceCategoryTypeAndDepartmentRequestHandler(ISchoolManagementRepository<MaintenanceCategory> MaintenanceCategoryRepository, IMapper mapper)
        {
            _MaintenanceCategoryRepository = MaintenanceCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<MaintenanceCategoryDto>> Handle(GetMaintemanceCategoryTypeAndDepartmentRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MaintenanceCategory> MaintenanceCategorys = _MaintenanceCategoryRepository.FilterWithInclude(x => x.MaintenanceTypeId == request.MaintenanceTypeId && x.DepartmentNameId == request.DepartmentNameId ,"DepartmentName", "MaintenanceType");

            var MaintenanceCategoryDtos = _mapper.Map<List<MaintenanceCategoryDto>>(MaintenanceCategorys);

            return MaintenanceCategoryDtos;
        }

    }
}
