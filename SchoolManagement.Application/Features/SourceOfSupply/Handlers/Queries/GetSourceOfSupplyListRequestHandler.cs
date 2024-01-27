using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SourceOfSupply;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Handlers.Queries
{
    public class GetSourceOfSupplyListRequestHandler : IRequestHandler<GetSourceOfSupplyListRequest, PagedResult<SourceOfSupplyDto>>
    {

        private readonly ISchoolManagementRepository<SourceOfSupply> _SourceOfSupplyRepository;

        private readonly IMapper _mapper;

        public GetSourceOfSupplyListRequestHandler(ISchoolManagementRepository<SourceOfSupply> SourceOfSupplyRepository, IMapper mapper)
        {
            _SourceOfSupplyRepository = SourceOfSupplyRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SourceOfSupplyDto>> Handle(GetSourceOfSupplyListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SourceOfSupply> UTOfficerCategories = _SourceOfSupplyRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.SourceOfSupplyId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SourceOfSupplyDtos = _mapper.Map<List<SourceOfSupplyDto>>(UTOfficerCategories);
            var result = new PagedResult<SourceOfSupplyDto>(SourceOfSupplyDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
