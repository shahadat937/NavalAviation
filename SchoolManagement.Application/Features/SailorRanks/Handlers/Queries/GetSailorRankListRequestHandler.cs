using AutoMapper;
using SchoolManagement.Application.DTOs.SailorRank;
using SchoolManagement.Application.Features.SailorRanks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.SailorRanks.Handlers.Queries
{
    public class GetSailorRankListRequestHandler : IRequestHandler<GetSailorRankListRequest, PagedResult<SailorRankDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SailorRank> _SailorRankRepository;

        private readonly IMapper _mapper;

        public GetSailorRankListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.SailorRank> SailorRankRepository, IMapper mapper)
        {
            _SailorRankRepository = SailorRankRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SailorRankDto>> Handle(GetSailorRankListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.SailorRank> SailorRanks = _SailorRankRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = SailorRanks.Count();
            SailorRanks = SailorRanks.OrderByDescending(x => x.SailorRankId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SailorRankDtos = _mapper.Map<List<SailorRankDto>>(SailorRanks);
            var result = new PagedResult<SailorRankDto>(SailorRankDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
