using AutoMapper;
using SchoolManagement.Application.DTOs.MaintenanceSubCategory;
using SchoolManagement.Application.Features.MaintenanceSubCategorys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenanceSubCategorys.Handlers.Queries
{
    public class GetSelectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryIdRequestHandler : IRequestHandler<GetSelectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryIdRequest, object>
    {

        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _MaintenanceSubCategoryRepository;

        private readonly IMapper _mapper;

        public GetSelectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryIdRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> MaintenanceSubCategoryRepository, IMapper mapper)
        {
            _MaintenanceSubCategoryRepository = MaintenanceSubCategoryRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSelectedAllowedExtensionBySubCategoryIdDepartmentIdAndCategoryIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<MaintenanceSubCategory> MaintenanceSubCategorys = _MaintenanceSubCategoryRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.MaintenanceCategoryId == request.MaintenanceCategoryId && x.MaintenanceSubCategoryId == request.MaintenanceSubCategoryId);

            var MaintenanceSubCategoryDtos = _mapper.Map<List<MaintenanceSubCategoryDto>>(MaintenanceSubCategorys);

            var value=MaintenanceSubCategoryDtos.Select(x => x.AllowedExtension).FirstOrDefault();
            return value;
        }
    }
}
