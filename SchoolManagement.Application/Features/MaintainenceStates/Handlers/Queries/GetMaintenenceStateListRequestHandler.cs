using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.MaintenenceState;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Queries;

namespace SchoolManagement.Application.Features.MaintenenceStates.Handlers.Queries
{
    public class GetMaintenenceStateListRequestHandler : IRequestHandler<GetMaintenenceStateListRequest, PagedResult<MaintenenceStateDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MaintenenceState> _MaintenenceStateRepository;

        private readonly IMapper _mapper;

        public GetMaintenenceStateListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MaintenenceState> MaintenenceStateRepository, IMapper mapper)
        {
            _MaintenenceStateRepository = MaintenenceStateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MaintenenceStateDto>> Handle(GetMaintenenceStateListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.MaintenenceState> MaintenenceStates = _MaintenenceStateRepository.FilterWithInclude(x => (x.ItemName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Trade");
            var totalCount = MaintenenceStates.Count();
            MaintenenceStates = MaintenenceStates.OrderByDescending(x => x.MaintenenceStateId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MaintenenceStateDtos = _mapper.Map<List<MaintenenceStateDto>>(MaintenenceStates);
            var result = new PagedResult<MaintenenceStateDto>(MaintenenceStateDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
