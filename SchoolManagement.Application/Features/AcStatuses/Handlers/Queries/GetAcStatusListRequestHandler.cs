using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AcStatuses.Requests.Queries;
using SchoolManagement.Application.DTOs.AcStatus;

namespace SchoolManagement.Application.Features.AcStatuses.Handlers.Queries
{
    public class GetAcStatusListRequestHandler : IRequestHandler<GetAcStatusListRequest, PagedResult<AcStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AcStatus> _AcStatusRepository;

        private readonly IMapper _mapper;

        public GetAcStatusListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.AcStatus> AcStatusRepository, IMapper mapper)
        {
            _AcStatusRepository = AcStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AcStatusDto>> Handle(GetAcStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.AcStatus> AcStatuss = _AcStatusRepository.FilterWithInclude(x => (x.ExcepRelease.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "AirCraftName", "Status");
            var totalCount = AcStatuss.Count();
            AcStatuss = AcStatuss.OrderByDescending(x => x.AcStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AcStatusDtos = _mapper.Map<List<AcStatusDto>>(AcStatuss);
            var result = new PagedResult<AcStatusDto>(AcStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
