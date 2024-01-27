using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Queries
{
    public class GetStockTransferNsdDetailRequestHandler : IRequestHandler<GetStockTransferNsdDetailRequest, StockTransferNsdDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.StockTransferNsd> _StockTransferNsdRepository;
        public GetStockTransferNsdDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.StockTransferNsd> StockTransferNsdRepository, IMapper mapper)
        {
            _StockTransferNsdRepository = StockTransferNsdRepository;
            _mapper = mapper;
        }
        public async Task<StockTransferNsdDto> Handle(GetStockTransferNsdDetailRequest request, CancellationToken cancellationToken)
        {
            var StockTransferNsd = await _StockTransferNsdRepository.Get(request.StockTransferNsdId);
            return _mapper.Map<StockTransferNsdDto>(StockTransferNsd);
        }
    }
}
