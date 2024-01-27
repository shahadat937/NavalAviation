using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetDemandListByDepartmentNameIdRequestHandler : IRequestHandler<GetDemandListByDepartmentNameIdRequest, PagedResult<DemandDto>>
    {
        private readonly ISchoolManagementRepository<Demand> _DemandRepository;

        private readonly IMapper _mapper;
        public GetDemandListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<Demand> DemandRepository, IMapper mapper)
        {
            _DemandRepository = DemandRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandDto>> Handle(GetDemandListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            //var validator = new QueryParamsValidator();
            //var validationResult = await validator.ValidateAsync(request.QueryParams);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);

            //IQueryable<Demand> Demands = _DemandRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId==1 , "DepartmentName", "Deno", "ItemDetail");

            //var DemandDtos = _mapper.Map<List<DemandDto>>(Demands);

            //return DemandDtos;


            IQueryable<Demand> Demands = _DemandRepository.FilterWithInclude(x => (x.ItemDetail.PartNo.Contains(request.QueryParams.SearchText) || x.ItemDetail.NameOfItem.Contains(request.QueryParams.SearchText) || x.DemandNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "Deno", "ItemDetail", "ConditionOfItem").Where(x => x.DepartmentNameId == request.DepartmentNameId && x.SparesCategoryId == 2);
            var totalCount = Demands.Count();
            Demands = Demands.OrderByDescending(x => x.DemandId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DemandDtos = _mapper.Map<List<DemandDto>>(Demands);
            var result = new PagedResult<DemandDto>(DemandDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }

    }
}
