using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MeaWorkShops.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MeaWorkShops.Handlers.Queries
{
    public class GetSelectedMeaWorkShopRequestHandler : IRequestHandler<GetSelectedMeaWorkShopRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MeaWorkShop> _MeaWorkShopRepository;


        public GetSelectedMeaWorkShopRequestHandler(ISchoolManagementRepository<MeaWorkShop> MeaWorkShopRepository)
        {
            _MeaWorkShopRepository = MeaWorkShopRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMeaWorkShopRequest request, CancellationToken cancellationToken)
        {
            ICollection<MeaWorkShop> codeValues = await _MeaWorkShopRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.MeaWorkShopId
            }).ToList();
            return selectModels;
        }
    }
}
