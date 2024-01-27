using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.MeaBlankFormats.Handlers.Queries
{
    public class GetMeaBlankFormatListRequestHandler : IRequestHandler<GetMeaBlankFormatListRequest, PagedResult<MeaBlankFormatDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MeaBlankFormat> _MeaBlankFormatRepository;

        private readonly IMapper _mapper;

        public GetMeaBlankFormatListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MeaBlankFormat> MeaBlankFormatRepository, IMapper mapper)
        {
            _MeaBlankFormatRepository = MeaBlankFormatRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MeaBlankFormatDto>> Handle(GetMeaBlankFormatListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.MeaBlankFormat> UTOfficerCategories = _MeaBlankFormatRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.MeaBlankFormatId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MeaBlankFormatDtos = _mapper.Map<List<MeaBlankFormatDto>>(UTOfficerCategories);
            var result = new PagedResult<MeaBlankFormatDto>(MeaBlankFormatDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
