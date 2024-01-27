using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OccasionOfDemand;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Handlers.Queries
{
    public class GetOccasionOfDemandListRequestHandler : IRequestHandler<GetOccasionOfDemandListRequest, PagedResult<OccasionOfDemandDto>>
    {

        private readonly ISchoolManagementRepository<OccasionOfDemand> _OccasionOfDemandRepository;

        private readonly IMapper _mapper;

        public GetOccasionOfDemandListRequestHandler(ISchoolManagementRepository<OccasionOfDemand> OccasionOfDemandRepository, IMapper mapper)
        {
            _OccasionOfDemandRepository = OccasionOfDemandRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OccasionOfDemandDto>> Handle(GetOccasionOfDemandListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<OccasionOfDemand> UTOfficerCategories = _OccasionOfDemandRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "FiscalYear");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.OccasionOfDemandId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var OccasionOfDemandDtos = _mapper.Map<List<OccasionOfDemandDto>>(UTOfficerCategories);
            var result = new PagedResult<OccasionOfDemandDto>(OccasionOfDemandDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
