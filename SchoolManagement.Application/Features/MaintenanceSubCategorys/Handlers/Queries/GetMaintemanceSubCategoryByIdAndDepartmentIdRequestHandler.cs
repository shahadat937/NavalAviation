using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetMaintemanceSubCategoryByIdAndDepartmentIdRequestHandler : IRequestHandler<GetMaintemanceSubCategoryByIdAndDepartmentIdRequest, List<MaintenanceSubCategoryDto>>
    {
        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;

        private readonly IMapper _mapper;
        public GetMaintemanceSubCategoryByIdAndDepartmentIdRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository, IMapper mapper)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;
            _mapper = mapper;
        }
         
        public async Task<List<MaintenanceSubCategoryDto>> Handle(GetMaintemanceSubCategoryByIdAndDepartmentIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MaintenanceSubCategory> MaintenanceSubCategorys = _MaintenanceSubCategoryRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.MaintenanceCategoryId == request.MaintenanceCategoryId,"MaintenanceCategory", "DepartmentName");

            var MaintenanceSubCategoryDtos = _mapper.Map<List<MaintenanceSubCategoryDto>>(MaintenanceSubCategorys);

            return MaintenanceSubCategoryDtos;
        }

    }
}
