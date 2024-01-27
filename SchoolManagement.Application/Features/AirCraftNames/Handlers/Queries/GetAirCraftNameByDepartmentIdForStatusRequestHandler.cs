using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetAirCraftNameByDepartmentIdForStatusRequestHandler : IRequestHandler<GetAirCraftNameByDepartmentIdForStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AirCraftName> _AirCraftNameRepository;

          
        public GetAirCraftNameByDepartmentIdForStatusRequestHandler(ISchoolManagementRepository<AirCraftName> AirCraftNameRepository)
        {
            _AirCraftNameRepository = AirCraftNameRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetAirCraftNameByDepartmentIdForStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<AirCraftName> AirCraftNames = await _AirCraftNameRepository.FilterAsync(x =>x.DepartmentNameId == request.DepartmentNameId & x.AircraftStatus == 1);
            List<SelectedModel> selectModels = AirCraftNames.Select(x => new SelectedModel
            {
                Text = x.Name, 
                Value = x.AirCraftNameId 
            }).ToList();
            return selectModels;
        }
    }
}
