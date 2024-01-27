using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Handlers.Queries
{
    public class GetSelectedPlaceOfDeliveryRequestHandler : IRequestHandler<GetSelectedPlaceOfDeliveryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<PlaceOfDelivery> _PlaceOfDeliveryRepository;


        public GetSelectedPlaceOfDeliveryRequestHandler(ISchoolManagementRepository<PlaceOfDelivery> PlaceOfDeliveryRepository)
        {
            _PlaceOfDeliveryRepository = PlaceOfDeliveryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedPlaceOfDeliveryRequest request, CancellationToken cancellationToken)
        {
            ICollection<PlaceOfDelivery> codeValues = await _PlaceOfDeliveryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.PlaceOfDeliveryId
            }).ToList();
            return selectModels;
        }
    }
}
