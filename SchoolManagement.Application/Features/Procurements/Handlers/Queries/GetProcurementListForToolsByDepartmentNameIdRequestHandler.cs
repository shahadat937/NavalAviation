using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.Procurement;
using SchoolManagement.Application.Features.Procurements.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Queries
{
    public class GetProcurementListForToolsByDepartmentNameIdRequestHandler : IRequestHandler<GetProcurementListForToolsByDepartmentNameIdRequest, PagedResult<ProcurementDto>>
    {
        private readonly ISchoolManagementRepository<Procurement> _ProcurementRepository;

        private readonly IMapper _mapper;
        public GetProcurementListForToolsByDepartmentNameIdRequestHandler(ISchoolManagementRepository<Procurement> ProcurementRepository, IMapper mapper)
        {
            _ProcurementRepository = ProcurementRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ProcurementDto>> Handle(GetProcurementListForToolsByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            

            IQueryable<Procurement> Procurements = _ProcurementRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || x.ItemDetail.NameOfItem.Contains(request.QueryParams.SearchText)  || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "ItemDetail", "Supplier").Where(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId == 2);
            var totalCount = Procurements.Count();
            Procurements = Procurements.OrderByDescending(x => x.ProcurementId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ProcurementDtos = _mapper.Map<List<ProcurementDto>>(Procurements);
            var result = new PagedResult<ProcurementDto>(ProcurementDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }

    }
}
