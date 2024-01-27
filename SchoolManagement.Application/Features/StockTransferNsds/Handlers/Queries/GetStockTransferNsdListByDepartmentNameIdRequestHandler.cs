using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Queries;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Queries
{
    public class GetStockTransferNsdListByDepartmentNameIdRequestHandler : IRequestHandler<GetStockTransferNsdListByDepartmentNameIdRequest, List<StockTransferNsdDto>>
    {
        private readonly ISchoolManagementRepository<StockTransferNsd> _StockTransferNsdRepository;

        private readonly IMapper _mapper;
        public GetStockTransferNsdListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<StockTransferNsd> StockTransferNsdRepository, IMapper mapper)
        {
            _StockTransferNsdRepository = StockTransferNsdRepository;
            _mapper = mapper;
        }

        public async Task<List<StockTransferNsdDto>> Handle(GetStockTransferNsdListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<StockTransferNsd> StockTransferNsds = _StockTransferNsdRepository.FilterWithInclude(x => x.DepartmentNameId == (request.DepartmentNameId !=0 ? request.DepartmentNameId : x.DepartmentNameId) && x.Status == request.Status, "DepartmentName", "ItemDetail", "ToolsLocation", "DemandAuthority");
            var totalCount = StockTransferNsds.Count();
            StockTransferNsds = StockTransferNsds.OrderByDescending(x => x.StockTransferNsdId);
            var StockTransferNsdDtos = _mapper.Map<List<StockTransferNsdDto>>(StockTransferNsds);

            return StockTransferNsdDtos;
        }

    }
}
