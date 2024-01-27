using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PlaceOfDelivery;
using SchoolManagement.Application.Features.PlaceOfDeliverys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PlaceOfDeliverys.Handlers.Queries
{
    public class GetPlaceOfDeliveryDetailRequestHandler : IRequestHandler<GetPlaceOfDeliveryDetailRequest, PlaceOfDeliveryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<PlaceOfDelivery> _PlaceOfDeliveryRepository;
        public GetPlaceOfDeliveryDetailRequestHandler(ISchoolManagementRepository<PlaceOfDelivery> PlaceOfDeliveryRepository, IMapper mapper)
        {
            _PlaceOfDeliveryRepository = PlaceOfDeliveryRepository;
            _mapper = mapper;
        }
        public async Task<PlaceOfDeliveryDto> Handle(GetPlaceOfDeliveryDetailRequest request, CancellationToken cancellationToken)
        {
            var PlaceOfDelivery = await _PlaceOfDeliveryRepository.Get(request.PlaceOfDeliveryId);
            return _mapper.Map<PlaceOfDeliveryDto>(PlaceOfDelivery);
        }
    }
}
