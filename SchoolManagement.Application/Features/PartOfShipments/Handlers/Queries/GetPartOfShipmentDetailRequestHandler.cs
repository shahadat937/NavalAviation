using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.PartOfShipment;
using SchoolManagement.Application.Features.PartOfShipments.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PartOfShipments.Handlers.Queries
{
    public class GetPartOfShipmentDetailRequestHandler : IRequestHandler<GetPartOfShipmentDetailRequest, PartOfShipmentDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<PartOfShipment> _PartOfShipmentRepository;
        public GetPartOfShipmentDetailRequestHandler(ISchoolManagementRepository<PartOfShipment> PartOfShipmentRepository, IMapper mapper)
        {
            _PartOfShipmentRepository = PartOfShipmentRepository;
            _mapper = mapper;
        }
        public async Task<PartOfShipmentDto> Handle(GetPartOfShipmentDetailRequest request, CancellationToken cancellationToken)
        {
            var PartOfShipment = await _PartOfShipmentRepository.Get(request.PartOfShipmentId);
            return _mapper.Map<PartOfShipmentDto>(PartOfShipment);
        }
    }
}
