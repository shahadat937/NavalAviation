using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemInspection;
using SchoolManagement.Application.Features.ItemInspections.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemInspections.Handlers.Queries
{
    public class GetItemInspectionDetailRequestHandler : IRequestHandler<GetItemInspectionDetailRequest, ItemInspectionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<ItemInspection> _ItemInspectionRepository;
        public GetItemInspectionDetailRequestHandler(ISchoolManagementRepository<ItemInspection> ItemInspectionRepository, IMapper mapper)
        {
            _ItemInspectionRepository = ItemInspectionRepository;
            _mapper = mapper;
        }
        public async Task<ItemInspectionDto> Handle(GetItemInspectionDetailRequest request, CancellationToken cancellationToken)
        {
            var ItemInspection = await _ItemInspectionRepository.Get(request.ItemInspectionId);
            return _mapper.Map<ItemInspectionDto>(ItemInspection);
        }
    }
}
