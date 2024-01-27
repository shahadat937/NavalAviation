using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.Demands;
using SchoolManagement.Application.Features.Demands.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Demands.Handlers.Queries
{
    public class GetDemandListRequestHandler : IRequestHandler<GetDemandListRequest, PagedResult<DemandDto>>
    {

        private readonly ISchoolManagementRepository<Demand> _DemandRepository;

        private readonly IMapper _mapper;

        public GetDemandListRequestHandler(ISchoolManagementRepository<Demand> DemandRepository, IMapper mapper)
        {
            _DemandRepository = DemandRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandDto>> Handle(GetDemandListRequest request, CancellationToken cancellationToken)
        {
            var DemandDtos = new List<DemandDto>();
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Demand> Demands = _DemandRepository.FilterWithInclude(x =>String.IsNullOrEmpty(request.QueryParams.SearchText), "DemandAuthority", "Deno", "FiscalYear", "DepartmentName", "ItemDetail");
            var totalCount = Demands.Count();

            Demands = Demands.OrderByDescending(x => x.DemandId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x=>x.DemandCompleteStatus == 0).Where(x => x.SparesCategoryId == request.SparesCategoryId);
            try
            {
                DemandDtos = _mapper.Map<List<DemandDto>>(Demands);
                //foreach (var item in DemandDtos)
                //{
                //    if(item.IsActive == true)
                //    {
                //        DemandDtos.Select(x=)
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            var result = new PagedResult<DemandDto>(DemandDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
