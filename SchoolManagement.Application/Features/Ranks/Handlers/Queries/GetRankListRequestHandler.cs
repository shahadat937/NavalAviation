using SchoolManagement.Application.Features.Ranks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Ranks.Handlers.Queries
{
    public class GetRankListRequestHandler : IRequestHandler<GetRankListRequest, PagedResult<RankDto>>
    {

        private readonly ISchoolManagementRepository<Rank> _RankRepository;

        private readonly IMapper _mapper;

        public GetRankListRequestHandler(ISchoolManagementRepository<Rank> RankRepository, IMapper mapper)
        {
            _RankRepository = RankRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RankDto>> Handle(GetRankListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Rank> UTOfficerCategories = _RankRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.RankId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RankDtos = _mapper.Map<List<RankDto>>(UTOfficerCategories);
            var result = new PagedResult<RankDto>(RankDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
