using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Districts.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Districts.Handlers.Queries
{
    public class GetSelectedDistrictByTypeHandler : IRequestHandler<GetSelectedDistrictByDivisionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<District> _DistrictRepository;

        public GetSelectedDistrictByTypeHandler(ISchoolManagementRepository<District> DistrictRepository)
        {
            _DistrictRepository = DistrictRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDistrictByDivisionRequest request, CancellationToken cancellationToken)
        {
            ICollection<District> Districts = await _DistrictRepository.FilterAsync(x => x.DivisionId == request.DivisionId);
            List<SelectedModel> selectModels = Districts.Select(x => new SelectedModel
            {
                Text = x.DistrictName,
                Value = x.DistrictId
            }).ToList();
            return selectModels;
        }
    }
}
