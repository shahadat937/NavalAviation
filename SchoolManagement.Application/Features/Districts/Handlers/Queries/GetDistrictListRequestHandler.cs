using AutoMapper;
using SchoolManagement.Application.DTOs.District;
using SchoolManagement.Application.Features.Districts.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.Districts.Handlers.Queries
{
    public class GetDistrictListRequestHandler : IRequestHandler<GetDistrictListRequest, PagedResult<DistrictDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.District> _DistrictRepository;

        private readonly IMapper _mapper;

        public GetDistrictListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.District> DistrictRepository, IMapper mapper)
        {
            _DistrictRepository = DistrictRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DistrictDto>> Handle(GetDistrictListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.District> Districts = _DistrictRepository.FilterWithInclude(x => (x.DistrictName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Division");
            var totalCount = Districts.Count();
            Districts = Districts.OrderByDescending(x => x.DistrictId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DistrictDtos = _mapper.Map<List<DistrictDto>>(Districts);
            var result = new PagedResult<DistrictDto>(DistrictDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
