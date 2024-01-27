using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Queries
{
    public class GetSelectedAirCraftNameRequestHandler : IRequestHandler<GetSelectedAirCraftNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AirCraftName> _AirCraftNameRepository;


        public GetSelectedAirCraftNameRequestHandler(ISchoolManagementRepository<AirCraftName> AirCraftNameRepository)
        {
            _AirCraftNameRepository = AirCraftNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAirCraftNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<AirCraftName> codeValues = await _AirCraftNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.AirCraftNameId
            }).ToList();
            return selectModels;
        }
    }
}
