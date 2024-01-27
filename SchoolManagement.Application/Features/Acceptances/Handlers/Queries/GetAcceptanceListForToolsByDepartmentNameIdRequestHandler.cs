using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.Acceptances;
using SchoolManagement.Application.Features.Acceptances.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Features.Acceptances.Handlers.Queries
{
    public class GetAcceptanceListForToolsByDepartmentNameIdRequestHandler : IRequestHandler<GetAcceptanceListForToolsByDepartmentNameIdRequest, PagedResult<AcceptanceDto>>
    {
        private readonly ISchoolManagementRepository<Acceptance> _AcceptanceRepository;

        private readonly IMapper _mapper;
        public GetAcceptanceListForToolsByDepartmentNameIdRequestHandler(ISchoolManagementRepository<Acceptance> AcceptanceRepository, IMapper mapper)
        {
            _AcceptanceRepository = AcceptanceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AcceptanceDto>> Handle(GetAcceptanceListForToolsByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            

            IQueryable<Acceptance> Acceptances = _AcceptanceRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || x.ItemDetail.NameOfItem.Contains(request.QueryParams.SearchText)  || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "ItemDetail").Where(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId == 2);
            var totalCount = Acceptances.Count();
            Acceptances = Acceptances.OrderByDescending(x => x.AcceptanceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AcceptanceDtos = _mapper.Map<List<AcceptanceDto>>(Acceptances);
            var result = new PagedResult<AcceptanceDto>(AcceptanceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }

    }
}
