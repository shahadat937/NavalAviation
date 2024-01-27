using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ToolsLocations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ToolsLocations.Handlers.Queries
{
    public class GetSelectedToolsLocationRequestHandler : IRequestHandler<GetSelectedToolsLocationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<ToolsLocation> _ToolsLocationRepository;


        public GetSelectedToolsLocationRequestHandler(ISchoolManagementRepository<ToolsLocation> ToolsLocationRepository)
        {
            _ToolsLocationRepository = ToolsLocationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedToolsLocationRequest request, CancellationToken cancellationToken)
        {
            ICollection<ToolsLocation> codeValues = await _ToolsLocationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ToolsLocationName,
                Value = x.ToolsLocationId
            }).ToList();
            return selectModels; 
        }
    }
}
