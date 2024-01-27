using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MaintenanceSchedules.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MaintenanceSchedules.Handlers.Queries   
{
    public class GetSelectedMaintenancePlanningByParametersFromSubCategoryRequestHandler : IRequestHandler<GetSelectedMaintenancePlanningByParametersFromSubCategoryRequest, int>
    {
        private readonly ISchoolManagementRepository<MaintenanceSubCategory> _maintenanceScheduleRepository;

           
        public GetSelectedMaintenancePlanningByParametersFromSubCategoryRequestHandler(ISchoolManagementRepository<MaintenanceSubCategory> maintenanceScheduleRepository)
        {
            _maintenanceScheduleRepository = maintenanceScheduleRepository;    
        }

        public async Task<int> Handle(GetSelectedMaintenancePlanningByParametersFromSubCategoryRequest request, CancellationToken cancellationToken)
        {
            var maintenanceSubCategorys = _maintenanceScheduleRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.MaintenanceCategoryId == request.MaintenanceCategoryId).FirstOrDefault();
           
            var maintenancePlanning = maintenanceSubCategorys.MaintenanceSubCategoryId;

            return maintenancePlanning ;
        }
    }
}
