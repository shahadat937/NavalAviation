using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ItemStor;
using SchoolManagement.Application.Features.ItemStors.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Queries
{
    public class GetBarcodePrintListByParamsRequestHandler : IRequestHandler<GetBarcodePrintListByParamsRequest, PagedResult<ItemStorDto>>
    {
        private readonly ISchoolManagementRepository<ItemStor> _ItemStorRepository;

        private readonly IMapper _mapper;
        public GetBarcodePrintListByParamsRequestHandler(ISchoolManagementRepository<ItemStor> ItemStorRepository, IMapper mapper)
        {
            _ItemStorRepository = ItemStorRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ItemStorDto>> Handle(GetBarcodePrintListByParamsRequest request, CancellationToken cancellationToken)
        {           
              IQueryable<ItemStor> ItemStors = _ItemStorRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || x.ItemDetail.NameOfItem.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "Deno", "ItemDetail", "SparesCategory").Where(x => x.DepartmentNameId == (request.DepartmentNameId != 0 ? request.DepartmentNameId : x.DepartmentNameId)  && x.SparesCategoryId == (request.SparesCategoryId != 0 ? request.SparesCategoryId : x.SparesCategoryId) && x.AvailableQty != 0);
              var totalCount = ItemStors.Count();
              ItemStors = ItemStors.OrderByDescending(x => x.ItemStorId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

              var ItemStorDtos = _mapper.Map<List<ItemStorDto>>(ItemStors);
              var result = new PagedResult<ItemStorDto>(ItemStorDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);
              return result;            
        }

    }
}
