using SchoolManagement.Application.Features.OfficersStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OfficersStatus;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OfficersStatuses.Handlers.Queries
{
    public class GetOfficersStatusListRequestHandler : IRequestHandler<GetOfficersStatusListRequest, PagedResult<OfficersStatusDto>>
    {

        private readonly ISchoolManagementRepository<OfficersStatus> _OfficersStatusRepository;

        private readonly IMapper _mapper;

        public GetOfficersStatusListRequestHandler(ISchoolManagementRepository<OfficersStatus> OfficersStatusRepository, IMapper mapper)
        {
            _OfficersStatusRepository = OfficersStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OfficersStatusDto>> Handle(GetOfficersStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<OfficersStatus> UTOfficerCategories = _OfficersStatusRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.OfficersStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var OfficersStatusDtos = _mapper.Map<List<OfficersStatusDto>>(UTOfficerCategories);
            var result = new PagedResult<OfficersStatusDto>(OfficersStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
