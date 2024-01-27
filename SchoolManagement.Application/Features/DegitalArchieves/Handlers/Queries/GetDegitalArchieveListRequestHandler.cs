using SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DegitalArchieve;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;


namespace SchoolManagement.Application.Features.DegitalArchieves.Handlers.Queries
{
    public class GetDegitalArchieveListRequestHandler : IRequestHandler<GetDegitalArchieveListRequest, PagedResult<DegitalArchieveDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieve> _DegitalArchieveRepository;

        private readonly IMapper _mapper;

        public GetDegitalArchieveListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.DegitalArchieve> DegitalArchieveRepository, IMapper mapper)
        {
            _DegitalArchieveRepository = DegitalArchieveRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DegitalArchieveDto>> Handle(GetDegitalArchieveListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.DegitalArchieve> UTOfficerCategories = _DegitalArchieveRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.DegitalArchieveId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DegitalArchieveDtos = _mapper.Map<List<DegitalArchieveDto>>(UTOfficerCategories);
            var result = new PagedResult<DegitalArchieveDto>(DegitalArchieveDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
