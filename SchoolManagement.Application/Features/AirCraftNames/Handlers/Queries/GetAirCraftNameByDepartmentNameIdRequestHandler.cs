using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetAirCraftNameByDepartmentNameIdRequestHandler : IRequestHandler<GetAirCraftNameByDepartmentNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AirCraftName> _AirCraftNameRepository;

          
        public GetAirCraftNameByDepartmentNameIdRequestHandler(ISchoolManagementRepository<AirCraftName> AirCraftNameRepository)
        {
            _AirCraftNameRepository = AirCraftNameRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetAirCraftNameByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<AirCraftName> AirCraftNames = await _AirCraftNameRepository.FilterAsync(x =>x.DepartmentNameId == request.DepartmentNameId);
            List<SelectedModel> selectModels = AirCraftNames.Select(x => new SelectedModel
            {
                Text = x.Name, 
                Value = x.AirCraftNameId 
            }).ToList();
            return selectModels;
        }
    }
}
