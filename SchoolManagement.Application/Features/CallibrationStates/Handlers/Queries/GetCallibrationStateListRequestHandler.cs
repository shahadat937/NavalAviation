using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.CallibrationState;
using SchoolManagement.Application.Features.CallibrationStates.Requests.Queries;

namespace SchoolManagement.Application.Features.CallibrationStates.Handlers.Queries
{
    public class GetCallibrationStateListRequestHandler : IRequestHandler<GetCallibrationStateListRequest, PagedResult<CallibrationStateDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CallibrationState> _CallibrationStateRepository;

        private readonly IMapper _mapper;

        public GetCallibrationStateListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CallibrationState> CallibrationStateRepository, IMapper mapper)
        {
            _CallibrationStateRepository = CallibrationStateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CallibrationStateDto>> Handle(GetCallibrationStateListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CallibrationState> CallibrationStates = _CallibrationStateRepository.FilterWithInclude(x => (x.ItemName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Trade");
            var totalCount = CallibrationStates.Count();
            CallibrationStates = CallibrationStates.OrderByDescending(x => x.CallibrationStateId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CallibrationStateDtos = _mapper.Map<List<CallibrationStateDto>>(CallibrationStates);
            var result = new PagedResult<CallibrationStateDto>(CallibrationStateDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
