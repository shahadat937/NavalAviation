using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemStor;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetItemStorDetailRequestHandler : IRequestHandler<GetItemStorDetailRequest, ItemStorDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ItemStor> _ItemStorRepository;
        public GetItemStorDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ItemStor> ItemStorRepository, IMapper mapper)
        {
            _ItemStorRepository = ItemStorRepository;
            _mapper = mapper;
        }
        public async Task<ItemStorDto> Handle(GetItemStorDetailRequest request, CancellationToken cancellationToken)
        {
            //var ItemStor = await _ItemStorRepository.Get(request.ItemStorId);
            //return _mapper.Map<ItemStorDto>(ItemStor);
            var ItemStor = _ItemStorRepository.FinedOneInclude(x => x.ItemStorId == request.ItemStorId, "DepartmentName", "Deno", "ItemDetail", "ConditionOfItem", "LifeLimitItem", "SparesCategory", "ToolsLocation");
            return _mapper.Map<ItemStorDto>(ItemStor);
        }
    }
}
