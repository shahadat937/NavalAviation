using AutoMapper;
using SchoolManagement.Application.DTOs.Religion;
using SchoolManagement.Application.Features.Religions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Religions.Handlers.Queries
{
    public class GetReligionListRequestHandler : IRequestHandler<GetReligionListRequest, PagedResult<ReligionDto>>
    {

        private readonly ISchoolManagementRepository<Religion> _ReligionRepository;

        private readonly IMapper _mapper;

        public GetReligionListRequestHandler(ISchoolManagementRepository<Religion> ReligionRepository, IMapper mapper)
        {
            _ReligionRepository = ReligionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ReligionDto>> Handle(GetReligionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Religion> Religions = _ReligionRepository.FilterWithInclude(x => (x.ReligionName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Religions.Count();
            Religions = Religions.OrderByDescending(x => x.ReligionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ReligionDtos = _mapper.Map<List<ReligionDto>>(Religions);
            var result = new PagedResult<ReligionDto>(ReligionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
